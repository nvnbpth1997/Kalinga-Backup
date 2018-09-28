using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Tracking.Entities;
using ITracking.Bussiness;
using Tracking.DataAccessLayer.IService.Respository;
using System.ComponentModel;
using static Tracking.Entities.Enums;
using System.Web;
using System.Web.Http;
using System.Net;
using System.IO;
using System.Net.Http;

namespace Tracking.Bussiness
{
    public class TrackingBusiness : ITrackingBusiness
    {
        private readonly IServiceLayer iservicetrack;
        /// <summary>
        /// Dependency injected for service layer
        /// </summary>
        /// <param name="iservice"></param>
        public TrackingBusiness(IServiceLayer iservice)
        {
            this.iservicetrack = iservice;
        }
        
      
        /// <summary>
        /// calls a method GetDefaulters() from service layer to fetch all the details of defaulters.
        /// SendEmailToDefaulters() to send mail.
        /// </summary>
        /// <returns></returns>
        public async Task SendEmails()
        {
                try
                {
                    List<Tuple<CmRecords, GlcSwipe, LeadDetails>>[] defaulters = await iservicetrack.GetDefaulters(true);
                    List<Tuple<CmRecords, GlcSwipe, LeadDetails>> late = defaulters[0];
                    List<Tuple<CmRecords, GlcSwipe, LeadDetails>> noSwipe = defaulters[1];
                    Admin PF = await iservicetrack.GetPF();
                    SendEmail.Handler.SendEmail send = new SendEmail.Handler.SendEmail();
                    await send.SendEmailToDefaulters(late, noSwipe, PF);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
        }
        /// <summary>
        /// Calls a method to send email for password reset.  
        /// </summary>
        /// <param name="givenEmail"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public async Task SendNewCode(string givenEmail, string newCode) {
            SendEmail.Handler.SendEmail send = new SendEmail.Handler.SendEmail();
            await send.SendCodeEmail(givenEmail, newCode);
        }
        /// <summary>
        /// calls a method GetLateSwipes() of service layer to get list of defaulters. 
        /// </summary>
        /// <returns>list of late swiped minds details</returns>
        public async Task<List<MindDetails>> GetLateSwipes()
        {
            return await iservicetrack.GetLateSwipes();
        }
        /// <summary>
        /// calls a method GetNotSwipes() of service layer to get list of defaulters. 
        /// </summary>
        /// <returns>list of not swiped minds details</returns>
        public async Task<List<MindDetails>> GetNotSwipes()
        {
            return await iservicetrack.GetNotSwipes();
        }
        /// <summary>
        /// calls a method GetOnTimeSwipes() of service layer to get list of defaulters. 
        /// </summary>
        /// <returns>list of swipe on time minds details </returns>
        public async Task<List<MindDetails>> GetOnTimeSwipes()
        {
            return await iservicetrack.GetOnTimeSwipes();
        }
        /// <summary>
        /// calls a method GetMind() of service layer to get list of swipe on time.
        /// </summary>
        /// <param name="Mid"></param>
        /// <returns> combine list of CmRecords, GlcSwipes, Residence, LeadDetails </returns>
        public async Task<MindDetails> GetMind(string Mid) {
            return await iservicetrack.GetMind(Mid);
        }
        
        /// <summary>
        /// calls a method GetRepeaterDefaulters() of service layer to get list of defaulters. 
        /// </summary>
        /// <returns>list of repeat defaulters</returns>

        public async Task<List<MindDetails>> GetRepeatDefaulters()
        {
            return await iservicetrack.GetRepeatDefaulters();
        }

        /// <summary>
        /// Method recieve minds swipe details from excel and set those to glclist.
        /// Calls method SetGlcSwipeValue() to set incomplete values into it.
        /// Calls method PostMindDetails() of service layer to save the list.
        /// Calls method SendEmails() to send the emails to defaulters and pf.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public async Task PostExcusedMinds(BindingList<ExcusedMinds> list) {
            BindingList<ExcuseData> excusedlist = new BindingList<ExcuseData>();
            foreach (var data in list) {
                var excusedmind = excusedlist.FirstOrDefault(ex => ex.Mid == data.MID);
                if (excusedmind == null)
                {
                    excusedlist.Add(new ExcuseData
                    {
                        Mid = data.MID,
                        Name = data.Name,
                        Lead = data.Lead,
                        Venue = data.Venue,
                        Comments = data.Comments
                    });
                }
                else {
                    excusedmind.Mid = data.MID;
                    excusedmind.Name = data.Name;
                    excusedmind.Lead = data.Lead;
                    excusedmind.Venue = data.Venue;
                    excusedmind.Comments = data.Comments;
                }
                //var excusedMind = g.FirstOrDefault(g => g.Mid == data.Mid && g.InsertedOn == date_checker); // variable to get element
            }
            await iservicetrack.PostExcusedMinds(excusedlist);
        }
        public async Task PostMindDetails(BindingList<ExcelData> list)
        {
            List<DateTime> holidaylist = await iservicetrack.GetHolidays();
            string today = DateTime.Now.ToString("M/d/yyyy");
            if(DateTime.Now.Day.ToString()=="Sunday" || DateTime.Now.Day.ToString() == "Saturday" || holidaylist.Contains(DateTime.Now))
            {
                throw new HttpResponseException(HttpStatusCode.NotAcceptable);
            }
            else
            {
                BindingList<GlcSwipe> glcswipes = new BindingList<GlcSwipe>();
                List<SwipeTrack> lastswipelist = await iservicetrack.GetLastSwipeDetails();
                List<CmRecords> cmrecordslist = await iservicetrack.GetCmRecords();
                List<ExcuseData> excusemindslist = await iservicetrack.GetExcusedMinds();
                if (lastswipelist.Count!=0 && lastswipelist.Where(swipe => swipe.Datetime.ToLongDateString() == DateTime.Now.ToLongDateString()).FirstOrDefault() != null) {
                    await iservicetrack.UndoSwipeTrackUpdate();
                }
                foreach(var data in list)
                {
                    if (data.Datetime.Contains(today))
                    {
                        var CmVerify = cmrecordslist.FirstOrDefault(cm => cm.Mid.Equals(data.Mid));
                        if (CmVerify != null)
                        {
                            if(excusemindslist.FirstOrDefault(ex => ex.Mid.Equals(data.Mid)) == null)
                            {
                                int index = lastswipelist.FindIndex(x => x.Mid == data.Mid);
                                if (index == -1)
                                {
                                    SwipeTrack swipetrack = new SwipeTrack()
                                    {
                                        Mid = data.Mid,
                                        Location = data.Swipedata,
                                        Datetime = DateTime.Parse(data.Datetime),
                                        PreDatetime = DateTime.Parse(data.Datetime).AddDays(-1),
                                        PreLocation = "N/A"
                                    };
                                    lastswipelist.Add(swipetrack);
                                    await iservicetrack.AddLastSwipe(swipetrack);
                                }
                                else
                                {
                                    if (
                                           (lastswipelist[index].Datetime.ToLongDateString() == DateTime.Parse(data.Datetime).ToLongDateString())
                                         && (((lastswipelist[index].Location.Contains("TRIPOD") || (lastswipelist[index].Location.Contains("BASEMENT") && !lastswipelist[index].Location.Contains("OPPOSITE"))
                                           || lastswipelist[index].Location.Contains("HANDICAP FLAP BARRIER")) && lastswipelist[index].Location.Contains("IN"))
                                           && ((String.Compare(DateTime.Parse(data.Datetime).ToLongTimeString(), "8:30:00") > 0)
                                           || !((data.Swipedata.Contains("TRIPOD") || data.Swipedata.Contains("BASEMENT") || data.Swipedata.Contains("HANDICAP FLAP BARRIER")) && data.Swipedata.Contains("OUT")))))
                                    {
                                        continue;
                                    }
                                    SwipeTrack swipetrack = new SwipeTrack();
                                    if (!(lastswipelist[index].Datetime.Equals(DateTime.Now)))
                                    {
                                        swipetrack.Mid = data.Mid;
                                        swipetrack.PreLocation = lastswipelist[index].Location;
                                        swipetrack.PreDatetime = lastswipelist[index].Datetime;
                                        swipetrack.Location = data.Swipedata;
                                        swipetrack.Datetime = DateTime.Parse(data.Datetime);
                                    }
                                    else
                                    {
                                        swipetrack.Mid = data.Mid;
                                        swipetrack.Location = data.Swipedata;
                                        swipetrack.Datetime = DateTime.Parse(data.Datetime);
                                        swipetrack.PreLocation = data.Swipedata;
                                        swipetrack.PreDatetime = DateTime.Parse(data.Datetime);
                                    }
                                    lastswipelist[index] = swipetrack;
                                    await iservicetrack.UpdateLastSwipe(swipetrack);
                                }
                                    if ((data.Swipedata.Contains("TRIPOD") || data.Swipedata.Contains("BASEMENT") || data.Swipedata.Contains("OPPOSITE") || data.Swipedata.Contains("HANDICAP FLAP BARRIER")))
                                    {
                                        string date_checker = DateTime.Now.ToString("yyyy-MM-dd");
                                        var glcList = glcswipes.FirstOrDefault(g => g.Mid == data.Mid && g.InsertedOn == date_checker); // variable to get element

                                        if (glcList == null)
                                        {
                                            string[] arr = data.Swipedata.Split(' ');
                                            string io = arr[arr.Length - 1];
                                            arr = arr.Take(arr.Count() - 1).ToArray();
                                            string location = String.Join(" ", arr);
                                            DateTime date = DateTime.Parse(data.Datetime);
                                            string swipetype = "";
                                            if (io == ((IO)0).ToString())
                                            {
                                                if (String.Compare(date.ToLongTimeString(), "8:30:00") > 0)
                                                {
                                                    swipetype = ((Enums.SwipeType)1).ToString();
                                                }
                                                else
                                                {
                                                    swipetype = ((SwipeType)0).ToString();
                                                }
                                                glcswipes.Add(new GlcSwipe
                                                {


                                                    Location = location,
                                                    Datetime = date,
                                                    Mid = data.Mid,
                                                    I_O = io,
                                                    InsertedOn = DateTime.Now.ToString("yyyy-MM-dd"),
                                                    Swipetype = swipetype
                                                });
                                            }
                                        }
                                        else
                                        {

                                            glcList.Datetime = DateTime.Parse(data.Datetime);
                                            glcList.Mid = data.Mid;
                                            string[] arr = data.Swipedata.Split(' ');
                                            glcList.I_O = arr[arr.Length - 1];
                                            arr = arr.Take(arr.Count() - 1).ToArray();
                                            glcList.Location = String.Join(" ", arr);
                                            glcList.InsertedOn = DateTime.Now.ToString("yyyy-MM-dd");
                                            if (glcList.I_O == ((IO)0).ToString())
                                            {
                                                if (String.Compare(glcList.Datetime.ToLongTimeString(), "8:30:00") > 0)
                                                {
                                                    glcList.Swipetype = ((Enums.SwipeType)1).ToString();
                                                }
                                                else
                                                {
                                                    glcList.Swipetype = ((SwipeType)0).ToString();
                                                }
                                            }

                                        }
                                    }
                            }
                        }
                    }
                }
                await iservicetrack.PostMindDetails(glcswipes);
                await SendEmails();
                await AlertMail();
            }
        }
        /// <summary>
        /// send alert mail to every campus mind when number of defaulters in a week increaces to certain point. 
        /// </summary>
        /// <returns></returns>
        public async Task AlertMail()
        {
            List<CmRecords> list = await iservicetrack.GetCmRecords();
            Admin Pf = await iservicetrack.GetPF();
            List<GlcSwipe> glclist = await iservicetrack.GetWeeklyDefaultersCount();
            if (glclist.Count >= 20000)
            {
                SendEmail.Handler.SendEmail send = new SendEmail.Handler.SendEmail();
                await send.AlterMail(list, Pf);
            }

        }

        public async Task<List<MindDetails>> GetThresholdDefaulters()
        {
            return await iservicetrack.GetGLCThresholdDefaulters();
        }
        public async Task<List<MindDetails>> GetLastWeekDefaulters()
        {

            List<GlcSwipe> glcswipelist = await iservicetrack.GetGLCSwipesLastWeek();
            //List<MindDetails> mindslistone = await iservicetrack.GetLateSwipesAll();
            //List<MindDetails> mindslisttwo = await iservicetrack.GetNotSwipesAll();
            //IEnumerable<MindDetails> finalminds = mindslistone.Concat(mindslisttwo);
            MindDetails support = new MindDetails();
            List<MindDetails> returnmindslist = new List<MindDetails>();
            //try
            //{
            //    foreach (var data in finalminds)
            //    {

            //        if (glcswipelist.FirstOrDefault(x => x.Mid == data.Mid) != null && returnmindslist.FirstOrDefault(cm => cm.Mid == data.Mid) == null)
            //        {
            //            returnmindslist.Add(data);
            //        }
            //    }
            //}

            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            foreach (var data in glcswipelist)

            {
                var x = returnmindslist.Where(y => y.Mid == data.Mid);
                if (x.Count() == 0)
                {
                    support = await iservicetrack.GetMind(data.Mid);
                    returnmindslist.Add(support);
                }
            }
            returnmindslist.OrderBy(x => x.FirstName);
            return returnmindslist;
        }
        public async Task<List<MindDetails>> GetLastThreeDaysDefaulters()
        {
            List<GlcSwipe> glcswipelist = await iservicetrack.GetGLCSwipesLastThreeDays();
            //List<MindDetails> mindslistone = await iservicetrack.GetLateSwipesAll();
            //List<MindDetails> mindslisttwo = await iservicetrack.GetNotSwipesAll();
            //IEnumerable<MindDetails> finalminds = mindslistone.Concat(mindslisttwo);
            MindDetails support = new MindDetails();
            List<MindDetails> returnmindslist = new List<MindDetails>();
            //foreach (var data in finalminds)
            //{
            //    if (glcswipelist.FirstOrDefault(x => x.Mid == data.Mid) != null && returnmindslist.FirstOrDefault(cm => cm.Mid == data.Mid) == null)
            //    {
            //        returnmindslist.Add(data);
            //    }
            //}
            //returnmindslist.OrderBy(x => x.FirstName);
            foreach (var data in glcswipelist)

            {
                var x = returnmindslist.Where(y => y.Mid == data.Mid);
                if (x.Count() == 0)
                {
                    support = await iservicetrack.GetMind(data.Mid);
                    returnmindslist.Add(support);
                }
            }
            returnmindslist.OrderBy(x => x.FirstName);
            return returnmindslist;
        }
        public async Task<List<MindDetails>> GetLastMonthDefaulters()
        {
            List<GlcSwipe> glcswipelist = await iservicetrack.GetGLCSwipesLastMonth();
            //List<MindDetails> mindslistone = await iservicetrack.GetLateSwipesAll();
            //List<MindDetails> mindslisttwo = await iservicetrack.GetNotSwipesAll();
            //IEnumerable<MindDetails> finalminds = mindslistone.Concat(mindslisttwo);
            MindDetails support = new MindDetails();
            List<MindDetails> returnmindslist = new List<MindDetails>();
            //foreach (var data in finalminds)
            //{
            //    if (glcswipelist.FirstOrDefault(x => x.Mid == data.Mid) != null && returnmindslist.FirstOrDefault(cm => cm.Mid == data.Mid) == null)
            //    {
            //        returnmindslist.Add(data);
            //    }
            //}
            foreach (var data in glcswipelist)

            {
                var x = returnmindslist.Where(y => y.Mid == data.Mid);
                if (x.Count() == 0)
                {
                    support = await iservicetrack.GetMind(data.Mid);
                    returnmindslist.Add(support);
                }
            }
            return returnmindslist.OrderBy(x => x.FirstName).ToList();
        }
        public async Task<List<MindDetails>> GetLastThreeMonthsDefaulters()
        {
            List<GlcSwipe> glcswipelist = await iservicetrack.GetGLCSwipesLastThreeMonths();
            //List<MindDetails> mindslistone = await iservicetrack.GetLateSwipesAll();
            //List<MindDetails> mindslisttwo = await iservicetrack.GetNotSwipesAll();
            //IEnumerable<MindDetails> finalminds = mindslistone.Concat(mindslisttwo);
            MindDetails support = new MindDetails();
            List<MindDetails> returnmindslist = new List<MindDetails>();
            //foreach (var data in finalminds)
            //{
            //    if (glcswipelist.FirstOrDefault(x => x.Mid == data.Mid) != null && returnmindslist.FirstOrDefault(cm => cm.Mid == data.Mid) == null)
            //    {
            //        returnmindslist.Add(data);
            //    }
            //}
            foreach (var data in glcswipelist)

            {
                var x = returnmindslist.Where(y => y.Mid == data.Mid);
                if (x.Count() == 0)
                {
                    support = await iservicetrack.GetMind(data.Mid);
                    returnmindslist.Add(support);
                }
            }
            return returnmindslist.OrderBy(x => x.FirstName).ToList();
        }
        public async Task PostSettingsDetails(Settings obj)
        {
            try
            {
                await iservicetrack.PostSettingsDetails(obj);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public async Task<Settings> GetSettingsDetails(string category)
        {
            return await iservicetrack.GetSettingsDetails(category);
        }

        public async Task<int> PostImage(HttpRequest httpRequest)
        {
            int index = 0;
            int uploadedImages = 0;

            if (httpRequest.Files.Count != 0)
            {
                foreach (var file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[index];
                    using (var binaryReader = new BinaryReader(postedFile.InputStream))
                    {
                        byte[] imageContent = binaryReader.ReadBytes(postedFile.ContentLength);
                        string imageURL = "data:image/jpg;base64," + Convert.ToBase64String(imageContent);
                        string imageName = Path.GetFileNameWithoutExtension(postedFile.FileName);
                        uploadedImages += await iservicetrack.PostImage(imageURL, imageName);
                    }
                    index++;
                }
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.PartialContent);
            }
            return uploadedImages;
        }

        public async Task PostCMDetails(BindingList<CMExcel> list)
        {

            if (list.Count != 0)
            {
                foreach (var data in list)
                {
                    CmRecords cm = new CmRecords()
                    {
                        Mid = data.Mid,
                        FirstName = data.FirstName,
                        LastName = data.LastName,
                        PhoneNo = data.PhoneNo,
                        Email = data.Email,
                        Gender = data.Gender,
                        Photograph = data.Photograph,
                        Batch = data.Batch
                    };
                    await iservicetrack.GetCMRecords(cm);
                }
            }
            else
                throw new HttpResponseException(HttpStatusCode.NoContent);  

        }
    }
}
