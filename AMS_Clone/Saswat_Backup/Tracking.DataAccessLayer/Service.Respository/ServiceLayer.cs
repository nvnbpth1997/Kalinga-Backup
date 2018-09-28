using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracking.DataAccessLayer.IService.Respository;
using Tracking.Entities;
using Tracking.DataAccessLayer.DbContext;
using System.Data.Entity;
using static Tracking.Entities.Enums;
using System.Web.Http;
using System.Net;

namespace Tracking.DataAccessLayer.Service.Respository
{
    public class ServiceLayer : IServiceLayer
    {

        private readonly TrackingDbContext dbContext;
        /// <summary>
        /// object of dbContext is been created.
        /// </summary>
        public ServiceLayer() {
            dbContext = new TrackingDbContext();
        }
        /// <summary>
        /// Update the db on upload of .xlsx file.
        /// </summary>
        /// <param name="glcList"></param>
        /// <returns></returns>
        ///

        public async Task PostExcusedMinds(BindingList<ExcuseData> excusedList)
        {
           
                foreach (var entity in dbContext.excused)
                {
                    dbContext.excused.Remove(entity);
                  //  await dbContext.SaveChangesAsync();
                }
            
            dbContext.excused.AddRange(excusedList);
            await dbContext.SaveChangesAsync();
        }
        public async Task PostMindDetails(BindingList<GlcSwipe> glcList)
        {
            
            try
            {
                var date = DateTime.Now.ToString("yyyy-MM-dd");
                var checkentrydate = await dbContext.glcswipes.Where(swipe => swipe.InsertedOn.Equals(date)).FirstOrDefaultAsync();
                if (checkentrydate != null)
                {
                    List<GlcSwipe> list = await dbContext.glcswipes.Where(swipe => swipe.InsertedOn.Equals(date) && (swipe.Swipetype.Equals(((SwipeType)2).ToString()) || swipe.Swipetype.Equals(((SwipeType)1).ToString()) || swipe.Swipetype.Equals(((SwipeType)3).ToString()))).ToListAsync();

                    // deletes the count from DefaultsCounts on re-upload of xlsx file.
                    foreach (var data in list)
                    {
                        if (data.Swipetype.Equals(((Enums.SwipeType)1).ToString()))
                        {
                            DefaultersCount dc = await dbContext.defaulterscount.Where(defaulter => defaulter.Mid == data.Mid).FirstOrDefaultAsync();
                            if (dc.LateSwipe > 0)
                            {
                                dc.LateSwipe--;
                            }
                        }
                        else if (data.Swipetype.Equals(((Enums.SwipeType)2).ToString()) || data.Swipetype.Equals(((Enums.SwipeType)3).ToString()))
                        {
                            DefaultersCount dc = await dbContext.defaulterscount.Where(defaulter => defaulter.Mid == data.Mid).FirstOrDefaultAsync();
                            if (dc.NotSwipe > 0)
                            {
                                dc.NotSwipe--;
                            }
                        }
                    }
                    //await UndoSwipeTrackUpdate();
                    await DeleteWrongEntry(DateTime.Now.ToString("yyyy-MM-dd"));
                    dbContext.glcswipes.AddRange(glcList);
                    await dbContext.SaveChangesAsync();
                }

                else
                {
                    dbContext.glcswipes.AddRange(glcList);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// To create list of mid who didn't swiped with their lead details, and their details. 
        /// </summary>
        /// <param name="increment"></param>
        /// <returns> list of tuples of array having LateSwipe and NotSwipe</returns>
        public async Task<List<Tuple<CmRecords, GlcSwipe, LeadDetails>>[]> GetDefaulters(bool increment)
        {
            string dateTimeCheck = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime check = DateTime.Parse(dateTimeCheck + " 0:00:00");
            DateTime checker = DateTime.Parse(dateTimeCheck + " 8:30:00");
            var noSwipe = await (from cm in dbContext.cmrecords
                                 join lead in dbContext.leaddetails
                                 on cm.Mid equals lead.Mid
                                 where (dbContext.swipetrack.Where(swipe => (swipe.Mid == cm.Mid) &&
                                 (DateTime.Compare(swipe.Datetime, check) >= 0)
                                 && ((swipe.Location == "MTK LC GFL TRIPOD 1 IN")
                                 || (swipe.Location == "MTK LC GFL TRIPOD 2 IN")
                                 || (swipe.Location == "MTK LC GFL TRIPOD 3 IN")
                                 || (swipe.Location == "MTK LC GFL TRIPOD 4 IN")
                                 || (swipe.Location == "MTK LC BASEMENT IN")
                                 || (swipe.Location == "MTK LC OPPOSITE BASEMENT IN")
                                 || (swipe.Location == "MTK LC GFL HANDICAP FLAP BARRIER IN"))).FirstOrDefault() == null)
                                 select new { cm, lead }).ToListAsync();
            var lateSwipe = await (from cm in dbContext.cmrecords
                                   join lead in dbContext.leaddetails
                                   on cm.Mid equals lead.Mid
                                   join swipe in dbContext.swipetrack
                                   on cm.Mid equals swipe.Mid
                                   where ((DateTime.Compare(swipe.Datetime, checker) > 0)&&(
                                   (swipe.Location == "MTK LC GFL TRIPOD 1 IN")
                                 || (swipe.Location == "MTK LC GFL TRIPOD 2 IN")
                                 || (swipe.Location == "MTK LC GFL TRIPOD 3 IN")
                                 || (swipe.Location == "MTK LC GFL TRIPOD 4 IN")
                                 || (swipe.Location == "MTK LC BASEMENT IN")
                                 || (swipe.Location == "MTK LC OPPOSITE BASEMENT IN")
                                 || (swipe.Location == "MTK LC GFL HANDICAP FLAP BARRIER IN")))
                                   //swipe.Swipetype == ((SwipeType)1).ToString() && swipe.InsertedOn == dateTimeCheck
                                   group swipe by new
                                   {
                                       Mid = cm.Mid,
                                       FirstName = cm.FirstName,
                                       LastName = cm.LastName,
                                       Email = cm.Email,
                                       PhoneNo = cm.PhoneNo,
                                       Gender = cm.Gender,
                                       Photograph = cm.Photograph,
                                       LeadName = lead.LeadName,
                                       LeadEmail = lead.LeadEmail,
                                       LeadPhoneNo = lead.LeadPhoneNo,
                                       Datetime = swipe.Datetime,
                                       Location = swipe.Location
                                   } into newGroup
                                   select new
                                   {
                                       Mid = newGroup.Key.Mid,
                                       FirstName = newGroup.Key.FirstName,
                                       LastName = newGroup.Key.LastName,
                                       Email = newGroup.Key.Email,
                                       PhoneNo = newGroup.Key.PhoneNo,
                                       Gender = newGroup.Key.Gender,
                                       Photograph = newGroup.Key.Photograph,
                                       LeadName = newGroup.Key.LeadName,
                                       LeadEmail = newGroup.Key.LeadEmail,
                                       LeadPhoneNo = newGroup.Key.LeadPhoneNo,
                                       Datetime = newGroup.Key.Datetime,
                                       Location = newGroup.Key.Location
                                   }).ToListAsync();

            List<Tuple<CmRecords, GlcSwipe, LeadDetails>> late = new List<Tuple<CmRecords, GlcSwipe, LeadDetails>>();
            List<Tuple<CmRecords, GlcSwipe, LeadDetails>> no = new List<Tuple<CmRecords, GlcSwipe, LeadDetails>>();
            List<ExcuseData> excused = await GetExcusedMinds();
            foreach (var n in noSwipe)
            {
                if (excused.Where(ex => ex.Mid == n.cm.Mid).FirstOrDefault() == null)
                {
                    GlcSwipe newSwipe = null;
                    if (increment)
                    {
                        SwipeTrack st = await dbContext.swipetrack.Where(x => x.Mid == n.cm.Mid).FirstOrDefaultAsync();
                        if (st != null)
                        {
                            string[] arr = st.Location.Split(' ');
                            string io = arr[arr.Length - 1];
                            arr = arr.Take(arr.Count() - 1).ToArray();
                            string location = String.Join(" ", arr);
                            if (st.Datetime.ToLongDateString() != DateTime.Now.ToLongDateString() || st.Location == "MTK MAIN GUNMAN POINT OUT")
                            {
                                newSwipe = new GlcSwipe()
                                {
                                    Mid = n.cm.Mid,
                                    InsertedOn = DateTime.Now.ToString("yyyy-MM-dd"),
                                    Swipetype = ((SwipeType)3).ToString(),
                                    Location = location,
                                    I_O = io,
                                    Datetime = st.Datetime
                                };
                            }
                            else
                            {
                                newSwipe = new GlcSwipe()
                                {
                                    Mid = n.cm.Mid,
                                    InsertedOn = DateTime.Now.ToString("yyyy-MM-dd"),
                                    Swipetype = ((SwipeType)2).ToString(),
                                    Location = location,
                                    I_O = io,
                                    Datetime = st.Datetime
                                };
                            }
                        }
                        else
                        {
                            newSwipe = new GlcSwipe()
                            {
                                Mid = n.cm.Mid,
                                InsertedOn = DateTime.Now.ToString("yyyy-MM-dd"),
                                Swipetype = ((SwipeType)3).ToString(),
                                Location = "N/A",
                                I_O = "N/A",
                                Datetime = DateTime.Now
                            };
                        }
                        dbContext.glcswipes.Add(newSwipe);
                        await SetDefaultCount(n.cm.Mid, false);
                    }
                    no.Add(new Tuple<CmRecords, GlcSwipe, LeadDetails>(n.cm, newSwipe, n.lead));
                }
            }
            foreach (var l in lateSwipe)
            {
                string[] arr = l.Location.Split(' ');
                string io = arr[arr.Length - 1];
                arr = arr.Take(arr.Count() - 1).ToArray();
                string location = String.Join(" ", arr);
                var cm = new CmRecords
                {
                    Mid = l.Mid,
                    FirstName = l.FirstName,
                    LastName = l.LastName,
                    Email = l.Email,
                    PhoneNo = l.PhoneNo,
                    Gender = l.Gender,
                    Photograph = l.Photograph
                };
                var swipe = new GlcSwipe
                {
                    Mid = l.Mid,
                    Datetime = l.Datetime,
                    Location = location,
                    I_O = io,
                    Swipetype = ((SwipeType)1).ToString()
                };
                var lead = new LeadDetails
                {
                    Mid = l.Mid,
                    LeadName = l.LeadName,
                    LeadEmail = l.LeadEmail,
                    LeadPhoneNo = l.LeadPhoneNo,
                };
                late.Add(new Tuple<CmRecords, GlcSwipe, LeadDetails>(cm, swipe, lead));
                if (increment)
                {
                    await SetDefaultCount(l.Mid, true);
                }
            }
            await dbContext.SaveChangesAsync();
            var result = new List<Tuple<CmRecords, GlcSwipe, LeadDetails>>[2];
            result[0] = late;
            result[1] = no;
            return result;
        }

        /// <summary>
        /// Get the list of late swipes.
        /// </summary>
        /// <returns> minds detail who swiped late</returns>
        public async Task<List<MindDetails>> GetLateSwipes()
        {
            DateTime date = DateTime.Today.AddHours(8).AddMinutes(30);
            DateTime date_mid = DateTime.Today;
            List<SwipeTrack> lateSwipes = await dbContext.swipetrack.Where(swipes => ((swipes.Location.Contains("TRIPOD") || swipes.Location.Contains("HANDICAP") || swipes.Location.Contains("BASEMENT")) && swipes.Location.Contains("IN")) && ((DateTime.Compare(swipes.Datetime, date) > 0))).ToListAsync<SwipeTrack>();

            List<MindDetails> combinedList = new List<MindDetails>();
            try
            {
                foreach (var swipe in lateSwipes)
                {
                    CmRecords cm = await dbContext.cmrecords.FindAsync(swipe.Mid);
                    LeadDetails lead = await dbContext.leaddetails.Where(l => l.Mid == swipe.Mid).FirstOrDefaultAsync();
                    DefaultersCount count = await dbContext.defaulterscount.Where(d => d.Mid == swipe.Mid).FirstOrDefaultAsync();
                    Residence res = await dbContext.residence.Where(r => r.Mid == swipe.Mid).FirstOrDefaultAsync();
                    string resString = res.Blockname[0] + "" + res.Floorname + res.Unitname + res.Roomname[0] + res.Bedname[1];
                    string[] arr = swipe.Location.Split(' ');
                    string io = arr[arr.Length - 1];
                    arr = arr.Take(arr.Count() - 1).ToArray();
                    string location = String.Join(" ", arr);
                    combinedList.Add(new MindDetails()
                    {
                        Mid = cm.Mid,
                        FirstName = cm.FirstName,
                        LastName = cm.LastName,
                        PhoneNo = cm.PhoneNo,
                        Email = cm.Email,
                        Gender = cm.Gender,
                        Photograph = cm.Photograph,
                        Location = swipe.Location,
                        I_O = io,
                        Datetime = swipe.Datetime,
                        Swipetype = ((SwipeType)1).ToString(),
                        InsertedOn = DateTime.Now.ToLongDateString(),
                        LeadName = lead.LeadName,
                        LeadEmail = lead.LeadEmail,
                        LeadPhoneNo = lead.LeadPhoneNo,
                        ResidenceString = resString,
                        LateSwipe = count.LateSwipe,
                        NotSwipe = count.NotSwipe
                    });
                }
               
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return combinedList.OrderBy(o => o.FirstName).ToList();
        }
        /// <summary>
        /// Get list of minds who did not swiped.
        /// </summary>
        /// <returns> list of minds with complete details those who didn't swiped </returns>
        public async Task<List<MindDetails>> GetNotSwipes()
        {
            List<MindDetails> combinedList = new List<MindDetails>();
            DateTime date = DateTime.Today.AddHours(8).AddMinutes(30);
            DateTime date_mid = DateTime.Today;
            List<SwipeTrack> notSwipes = await dbContext.swipetrack.Where(swipes => (!(swipes.Location.Contains("TRIPOD") || swipes.Location.Contains("HANDICAP") || swipes.Location.Contains("BASEMENT")) && swipes.Location.Contains("IN")) || ((DateTime.Compare(swipes.Datetime, date_mid) < 0))).ToListAsync<SwipeTrack>();
            foreach (var swipe in notSwipes) {
                CmRecords cm = await dbContext.cmrecords.FindAsync(swipe.Mid);
                LeadDetails lead = await dbContext.leaddetails.Where(l => l.Mid == swipe.Mid).FirstOrDefaultAsync();
                DefaultersCount count = await dbContext.defaulterscount.Where(d => d.Mid == swipe.Mid).FirstOrDefaultAsync();
                Residence res = await dbContext.residence.Where(r => r.Mid == swipe.Mid).FirstOrDefaultAsync();
                string resString = res.Blockname[0] + "" + res.Floorname + res.Unitname + res.Roomname[0] + res.Bedname[1];
                string[] arr = swipe.Location.Split(' ');
                string io = arr[arr.Length - 1];
                arr = arr.Take(arr.Count() - 1).ToArray();
                string location = String.Join(" ", arr);
                combinedList.Add(new MindDetails()
                {
                    Mid = cm.Mid,
                    FirstName = cm.FirstName,
                    LastName = cm.LastName,
                    PhoneNo = cm.PhoneNo,
                    Email = cm.Email,
                    Gender = cm.Gender,
                    Photograph = cm.Photograph,
                    Location = swipe.Location,
                    I_O = io,
                    Datetime = swipe.Datetime,
                    Swipetype = ((SwipeType)2).ToString(),
                    InsertedOn = DateTime.Now.ToLongDateString(),
                    LeadName = lead.LeadName,
                    LeadEmail = lead.LeadEmail,
                    LeadPhoneNo = lead.LeadPhoneNo,
                    ResidenceString = resString,
                    LateSwipe = count.LateSwipe,
                    NotSwipe = count.NotSwipe
                });
            }
            return combinedList.OrderBy(o => o.FirstName).ToList();
        }
        /// <summary>
        /// Get the details of all swiped on time minds details.
        /// </summary>
        /// <returns> return list of swiped on time minds details </returns>
        public async Task<List<MindDetails>> GetOnTimeSwipes()
        {
            
            DateTime date = DateTime.Today.AddHours(8).AddMinutes(30);
            DateTime date_mid = DateTime.Today;
            List<SwipeTrack> onTimeSwipes = await dbContext.swipetrack.Where(swipes => ((swipes.Location.Contains("TRIPOD") || swipes.Location.Contains("HANDICAP") || swipes.Location.Contains("BASEMENT")) && swipes.Location.Contains("IN"))&&((DateTime.Compare(swipes.Datetime,date_mid)>0)&&(DateTime.Compare(swipes.Datetime, date)<=0))).ToListAsync<SwipeTrack>();
            List<MindDetails> combinedList = new List<MindDetails>();
            foreach (var swipe in onTimeSwipes)
            {
                CmRecords cm = await dbContext.cmrecords.FindAsync(swipe.Mid);
                LeadDetails lead = await dbContext.leaddetails.Where(l => l.Mid == swipe.Mid).FirstOrDefaultAsync();
                DefaultersCount count = await dbContext.defaulterscount.Where(d => d.Mid == swipe.Mid).FirstOrDefaultAsync();
                if (count == null)
                {
                    DefaultersCount defaulter = new DefaultersCount()
                    {
                        Mid = swipe.Mid,
                        LateSwipe = 0,
                        NotSwipe = 0
                    };
                    dbContext.defaulterscount.Add(defaulter);
                    await dbContext.SaveChangesAsync();
                    count = defaulter;
                }
                Residence res = await dbContext.residence.Where(r => r.Mid == swipe.Mid).FirstOrDefaultAsync();
                string resString = res.Blockname[0] +""+ res.Floorname + res.Unitname + res.Roomname[0] + res.Bedname[1];
                string[] arr = swipe.Location.Split(' ');
                string io = arr[arr.Length - 1];
                arr = arr.Take(arr.Count() - 1).ToArray();
                string location = String.Join(" ", arr);

                combinedList.Add(new MindDetails()
                {
                    Mid = cm.Mid,
                    FirstName = cm.FirstName,
                    LastName = cm.LastName,
                    PhoneNo = cm.PhoneNo,
                    Email = cm.Email,
                    Gender = cm.Gender,
                    Photograph = cm.Photograph,
                    Location = location,
                    I_O = io,
                    Datetime = swipe.Datetime,
                    Swipetype = ((SwipeType)0).ToString(),
                    InsertedOn = DateTime.Now.ToLongDateString(),
                    LeadName = lead.LeadName,
                    LeadEmail = lead.LeadEmail,
                    LeadPhoneNo = lead.LeadPhoneNo,
                    ResidenceString = resString,
                    LateSwipe = count.LateSwipe,
                    NotSwipe = count.NotSwipe
                });
            }
            return combinedList.OrderBy(o => o.FirstName).ToList();
        }
        /// <summary>
        /// To get details of the selected mind
        /// </summary>
        /// <param name="Mid"></param>
        /// <returns> selected mind details returned</returns>
        public async Task<MindDetails> GetMind(string Mid) {
            CmRecords cm = await dbContext.cmrecords.FindAsync(Mid);
            GlcSwipe swipe = await dbContext.glcswipes.Where(s => s.Mid == Mid).FirstOrDefaultAsync();
            LeadDetails lead = await dbContext.leaddetails.Where(l => l.Mid == Mid).FirstOrDefaultAsync();
            DefaultersCount count = await dbContext.defaulterscount.Where(d => d.Mid == Mid).FirstOrDefaultAsync();
            Residence res = await dbContext.residence.Where(r => r.Mid == Mid).FirstOrDefaultAsync();
            string resString = res.Blockname[0] + "" + res.Floorname + res.Unitname + res.Roomname[0] + res.Bedname[1];
            return new MindDetails()
            {
                Mid = cm.Mid,
                FirstName = cm.FirstName,
                LastName = cm.LastName,
                PhoneNo = cm.PhoneNo,
                Email = cm.Email,
                Gender = cm.Gender,
                Photograph = cm.Photograph,
                Location = swipe.Location,
                I_O = swipe.I_O,
                Datetime = swipe.Datetime,
                Swipetype = swipe.Swipetype,
                InsertedOn = swipe.InsertedOn,
                LeadName = lead.LeadName,
                LeadEmail = lead.LeadEmail,
                LeadPhoneNo = lead.LeadPhoneNo,
                ResidenceString = resString,
                LateSwipe = count.LateSwipe,
                NotSwipe = count.NotSwipe
            };
        }

        /// <summary>
        /// Deletes the data from Glcswipe.
        /// </summary>
        /// <param name="date">Inserted_On</param>
        /// <returns></returns>
        public async Task DeleteWrongEntry(string date)
        {
            dbContext.glcswipes.RemoveRange(dbContext.glcswipes.Where(swipe => swipe.InsertedOn.Equals(date)));
            await dbContext.SaveChangesAsync();
        }
        /// <summary>
        /// Update the count of LateSwipe or NotSwipe for passed Mid.
        /// </summary>
        /// <param name="Mid"></param>
        /// <param name="late_no"></param>
        /// <returns></returns>
        public async Task SetDefaultCount(string Mid, bool late_no) {
            DefaultersCount dc = await dbContext.defaulterscount.Where(defaulter => defaulter.Mid == Mid).FirstOrDefaultAsync();
            if (late_no)
            {
                if (dc == null)
                {
                    dbContext.defaulterscount.Add(new DefaultersCount() { Mid = Mid, LateSwipe = 1, NotSwipe = 0 });
                }
                else dc.LateSwipe++;
            }
            else
            {
                if (dc == null)
                {
                    dbContext.defaulterscount.Add(new DefaultersCount() { Mid = Mid, LateSwipe = 0, NotSwipe = 1 });
                }
                else dc.NotSwipe++;
            }
        }
        /// <summary>
        /// To get PF details from Admins.
        /// </summary>
        /// <returns>Pf detail</returns>
        public async Task<Admin> GetPF() {
            return await dbContext.admin.Where(admin => admin.RoleName == ((AdminRoles)0).ToString()).FirstOrDefaultAsync();
        }
        /// <summary>
        /// Get list of repeat defaulters
        /// </summary>
        /// <returns> complete details for defaulters</returns>
        public async Task<List<MindDetails>> GetRepeatDefaulters()
        {
            List<MindDetails> combinedList = new List<MindDetails>();
            List<DefaultersCount> notSwipes = await dbContext.defaulterscount.Where(swipes => swipes.LateSwipe + swipes.NotSwipe > 1 ).ToListAsync<DefaultersCount>();
            foreach (var swipe in notSwipes)
            {
                CmRecords cm = await dbContext.cmrecords.FindAsync(swipe.Mid);
                LeadDetails lead = await dbContext.leaddetails.Where(l => l.Mid == swipe.Mid).FirstOrDefaultAsync();
                DefaultersCount count = await dbContext.defaulterscount.Where(d => d.Mid == swipe.Mid).FirstOrDefaultAsync();
                Residence res = await dbContext.residence.Where(r => r.Mid == swipe.Mid).FirstOrDefaultAsync();
                string resString = res.Blockname[0] + res.Floorname[0] + "U" + res.Unitname[0] + res.Roomname[0] + res.Bedname[0];
                combinedList.Add(new MindDetails()
                {
                    Mid = cm.Mid,
                    FirstName = cm.FirstName,
                    LastName = cm.LastName,
                    PhoneNo = cm.PhoneNo,
                    Email = cm.Email,
                    Gender = cm.Gender,
                    Photograph = cm.Photograph,
                    LeadName = lead.LeadName,
                    LeadEmail = lead.LeadEmail,
                    LeadPhoneNo = lead.LeadPhoneNo,
                    ResidenceString = resString,
                    LateSwipe = count.LateSwipe,
                    NotSwipe = count.NotSwipe
                });
            }
            return combinedList.OrderBy(o => o.FirstName).ToList();
        }
        /// <summary>
        /// Get list of holiday dates
        /// </summary>
        /// <returns> complete details of holiday dates</returns>
        public async Task<List<DateTime>> GetHolidays()
        {
            return await dbContext.holidays.Select(x => x.Datetime).ToListAsync();
        }
        public async Task<List<ExcuseData>> GetExcusedMinds() {
            return await dbContext.excused.ToListAsync();

        }
        /// <summary>
        /// Get last swipe details.
        /// </summary>
        /// <returns></returns>
        public async Task<List<SwipeTrack>> GetLastSwipeDetails()
        { 
            return await dbContext.swipetrack.Select(x=>x).ToListAsync();
        }
        /// <summary>
        /// Add thelast swipe details,
        /// </summary>
        /// <param name="swipetrack"></param>
        /// <returns></returns>
        public async Task AddLastSwipe(SwipeTrack swipetrack)
        {
            dbContext.swipetrack.Add(swipetrack);
            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (Exception e){
                Console.WriteLine(e);
            }
        }
        /// <summary>
        /// Updates the last swipe of existing mid.
        /// </summary>
        /// <param name="swipetrack"></param>
        /// <returns></returns>
        public async Task UpdateLastSwipe(SwipeTrack swipetrack)
        {
            SwipeTrack st = await dbContext.swipetrack.Where(x => x.Mid == swipetrack.Mid).FirstOrDefaultAsync();
            if (swipetrack.Datetime > st.Datetime)
            {
                st.Datetime = swipetrack.Datetime;
                st.Location = swipetrack.Location;
                await dbContext.SaveChangesAsync();
            }
        }
        public async Task<List<CmRecords>> GetCmRecords()
        {
            List<CmRecords> list = await dbContext.cmrecords.Select(cm => cm).ToListAsync<CmRecords>();
            return list;
        }
        public async Task<List<GlcSwipe>> GetWeeklyDefaultersCount()
        {
            string date = (DateTime.Now - TimeSpan.FromDays(7)).ToString("yyyy-MM-dd");
            return await dbContext.glcswipes.Where(x => x.InsertedOn.CompareTo(date)==1 || x.InsertedOn.CompareTo(date)==0  && x.Swipetype == ((SwipeType)1).ToString() && x.Swipetype == ((SwipeType)2).ToString()).ToListAsync<GlcSwipe>();
        }
        public async Task UndoSwipeTrackUpdate()
        {
            List<SwipeTrack> list = await GetLastSwipeDetails();
            foreach(var data in list)
            {
                data.Location = data.PreLocation;
                data.Datetime = data.PreDatetime;
                try
                {
                    await dbContext.SaveChangesAsync();
                }
                catch (Exception e) {
                    Console.WriteLine(e);
                }
            }
        }
        public async Task<List<MindDetails>> GetLateSwipesAll()
        {
            string Inserted_On = DateTime.Now.ToString("yyyy-MM-dd");
            List<GlcSwipe> lateSwipes = await dbContext.glcswipes.Where(swipes => swipes.Swipetype == ((SwipeType)1).ToString()).ToListAsync<GlcSwipe>();
            List<MindDetails> combinedList = new List<MindDetails>();
            try
            {
                foreach (var swipe in lateSwipes)
                {
                    CmRecords cm = await dbContext.cmrecords.FindAsync(swipe.Mid);
                    LeadDetails lead = await dbContext.leaddetails.Where(l => l.Mid == swipe.Mid).FirstOrDefaultAsync();
                    DefaultersCount count = await dbContext.defaulterscount.Where(d => d.Mid == swipe.Mid).FirstOrDefaultAsync();
                    Residence res = await dbContext.residence.Where(r => r.Mid == swipe.Mid).FirstOrDefaultAsync();
                    string resString = res.Blockname[0] + "" + res.Floorname + res.Unitname + res.Roomname[0] + res.Bedname[1];
                    combinedList.Add(new MindDetails()
                    {
                        Mid = cm.Mid,
                        FirstName = cm.FirstName,
                        LastName = cm.LastName,
                        PhoneNo = cm.PhoneNo,
                        Email = cm.Email,
                        Gender = cm.Gender,
                        Photograph = cm.Photograph,
                        Location = swipe.Location,
                        I_O = swipe.I_O,
                        Datetime = swipe.Datetime,
                        Swipetype = swipe.Swipetype,
                        InsertedOn = swipe.InsertedOn,
                        LeadName = lead.LeadName,
                        LeadEmail = lead.LeadEmail,
                        LeadPhoneNo = lead.LeadPhoneNo,
                        ResidenceString = resString,
                        LateSwipe = count.LateSwipe,
                        NotSwipe = count.NotSwipe
                    });
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return combinedList.OrderBy(o => o.FirstName).ToList();
        }
        public async Task<List<MindDetails>> GetNotSwipesAll()
        {
            List<MindDetails> combinedList = new List<MindDetails>();
            string Inserted_On = DateTime.Now.ToString("yyyy-MM-dd");
            List<GlcSwipe> notSwipes = await dbContext.glcswipes.Where(swipes => swipes.Swipetype == ((SwipeType)2).ToString()).ToListAsync<GlcSwipe>();
            foreach (var swipe in notSwipes)
            {
                CmRecords cm = await dbContext.cmrecords.FindAsync(swipe.Mid);
                LeadDetails lead = await dbContext.leaddetails.Where(l => l.Mid == swipe.Mid).FirstOrDefaultAsync();
                DefaultersCount count = await dbContext.defaulterscount.Where(d => d.Mid == swipe.Mid).FirstOrDefaultAsync();
                Residence res = await dbContext.residence.Where(r => r.Mid == swipe.Mid).FirstOrDefaultAsync();
                string resString = res.Blockname[0] + "" + res.Floorname + res.Unitname + res.Roomname[0] + res.Bedname[1];
                combinedList.Add(new MindDetails()
                {
                    Mid = cm.Mid,
                    FirstName = cm.FirstName,
                    LastName = cm.LastName,
                    PhoneNo = cm.PhoneNo,
                    Email = cm.Email,
                    Gender = cm.Gender,
                    Photograph = cm.Photograph,
                    Location = swipe.Location,
                    I_O = swipe.I_O,
                    Datetime = swipe.Datetime,
                    Swipetype = swipe.Swipetype,
                    InsertedOn = swipe.InsertedOn,
                    LeadName = lead.LeadName,
                    LeadEmail = lead.LeadEmail,
                    LeadPhoneNo = lead.LeadPhoneNo,
                    ResidenceString = resString,
                    LateSwipe = count.LateSwipe,
                    NotSwipe = count.NotSwipe
                });
            }
            return combinedList.OrderBy(o => o.FirstName).ToList();
        }
        public async Task<List<MindDetails>> GetGLCThresholdDefaulters()
        {
            List<MindDetails> combinedList = new List<MindDetails>();
            List<DefaultersCount> notSwipes = await dbContext.defaulterscount.Where(swipes => swipes.LateSwipe + swipes.NotSwipe > 3).ToListAsync<DefaultersCount>();
            foreach (var swipe in notSwipes)
            {
                CmRecords cm = await dbContext.cmrecords.FindAsync(swipe.Mid);
                LeadDetails lead = await dbContext.leaddetails.Where(l => l.Mid == swipe.Mid).FirstOrDefaultAsync();
                DefaultersCount count = await dbContext.defaulterscount.Where(d => d.Mid == swipe.Mid).FirstOrDefaultAsync();
                Residence res = await dbContext.residence.Where(r => r.Mid == swipe.Mid).FirstOrDefaultAsync();
                string resString = res.Blockname[0] + res.Floorname[0] + "U" + res.Unitname[0] + res.Roomname[0] + res.Bedname[0];
                combinedList.Add(new MindDetails()
                {
                    Mid = cm.Mid,
                    FirstName = cm.FirstName,
                    LastName = cm.LastName,
                    PhoneNo = cm.PhoneNo,
                    Email = cm.Email,
                    Gender = cm.Gender,
                    Photograph = cm.Photograph,
                    LeadName = lead.LeadName,
                    LeadEmail = lead.LeadEmail,
                    LeadPhoneNo = lead.LeadPhoneNo,
                    ResidenceString = resString,
                    LateSwipe = count.LateSwipe,
                    NotSwipe = count.NotSwipe
                });
            }
            return combinedList.OrderBy(o => o.FirstName).ToList();
        }
        public async Task<List<GlcSwipe>> GetGLCSwipesLastWeek()
        {
            DateTime date = DateTime.Now.AddDays(-7);
            return await dbContext.glcswipes.Where(x => x.Datetime >= date && !(x.Swipetype.Equals("SwipeOnTime"))).ToListAsync<GlcSwipe>();
        }
        public async Task<List<GlcSwipe>> GetGLCSwipesLastThreeDays()
        {
            DateTime date = DateTime.Now.AddDays(-3);
            return await dbContext.glcswipes.Where(x => x.Datetime >= date && !(x.Swipetype.Equals("SwipeOnTime"))).ToListAsync<GlcSwipe>();

        }
        public async Task<List<GlcSwipe>> GetGLCSwipesLastMonth()
        {
            DateTime date = DateTime.Now.AddMonths(-1);
            return await dbContext.glcswipes.Where(x => x.Datetime >= date && !(x.Swipetype.Equals("SwipeOnTime"))).ToListAsync<GlcSwipe>();
        }
        public async Task<List<GlcSwipe>> GetGLCSwipesLastThreeMonths()
        {
            DateTime date = DateTime.Now.AddMonths(-3);
            return await dbContext.glcswipes.Where(x => x.Datetime >= date && !(x.Swipetype.Equals("SwipeOnTime"))).ToListAsync<GlcSwipe>();
        }
        public async Task PostSettingsDetails(Settings obj)
        {
            try
            {
                Settings row = await dbContext.settings.Where(x => x.Category == obj.Category).FirstAsync();
                dbContext.settings.Remove(row);
                dbContext.settings.Add(obj);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public async Task<Settings> GetSettingsDetails(string category)
        {
            return await dbContext.settings.Where(x => x.Category == category).FirstAsync();
        }

        public async Task<int> PostImage(string imageURL, string imageName)
        {
            {
                // get all Persons with FirstName equals name
                CmRecords personToUpdate = dbContext.cmrecords.Where(o => o.Mid.Equals(imageName)).First();
                personToUpdate.Photograph = imageURL;

                int uploadedImages = 0;
                // update LastName for all Persons in personsToUpdate
                try
                {
                    dbContext.Entry(personToUpdate).State = EntityState.Modified;
                    uploadedImages = await dbContext.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw new HttpResponseException(HttpStatusCode.Forbidden);
                }

                return uploadedImages;
            }
        }

        public async Task GetCMRecords(CmRecords cm)
        {
            dbContext.cmrecords.Add(cm);
            await dbContext.SaveChangesAsync();
        }

    }
}