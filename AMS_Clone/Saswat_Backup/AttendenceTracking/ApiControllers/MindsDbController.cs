using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ITracking.Bussiness;
using Tracking.Bussiness;
using Tracking.Entities;
using System.Web.Http.Cors;
using System.Web;
using System.IO;
using System.ComponentModel;

namespace AttendenceTracking.ApiControllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class MindsDbController : ApiController
    {
        private readonly ITrackingBusiness itrack;
        /// <summary>
        /// Dependency injected of business layer
        /// </summary>
        /// <param name="track"></param>
        public MindsDbController(ITrackingBusiness track)
        {
            itrack = track;
        }

        /// <summary>
        /// Gets the late swipes defaulters details
        /// </summary>
        /// <returns> details like CmRecords, GlcSwipes, LeadDetails, Defaulters Count, Residence </returns>
        [Route("api/MindsDb/GetLateSwipes")]
        [HttpGet]
        public async Task<List<MindDetails>> GetLateSwipes()
        {
            return await itrack.GetLateSwipes();
        }

        /// <summary>
        /// Gets the not swipes defaulters details
        /// </summary>
        /// <returns> details like CmRecords, GlcSwipes, LeadDetails, Defaulters Count, Residence </returns>
        [Route("api/MindsDb/GetNotSwipes")]
        [HttpGet]
        public async Task<List<MindDetails>> GetNotSwipes()
        {
            return await itrack.GetNotSwipes();
        }

        /// <summary>
        /// Gets the on swipes minds details
        /// </summary>
        /// <returns> details like CmRecords, GlcSwipes, LeadDetails, Defaulters Count, Residence </returns>
        [HttpGet]
        [Route("api/MindsDb/GetOnTimeSwipes")]
        public async Task<List<MindDetails>> GetOnTimeSwipes()
        {
            return await itrack.GetOnTimeSwipes();
        }

        /// <summary>
        /// Gets the repeat defaulters details
        /// </summary>
        /// <returns> details like CmRecords, GlcSwipes, LeadDetails, Defaulters Count, Residence </returns>
        [HttpGet]
        [Route("api/MindsDb/GetRepeatDefaulters")]
        public async Task<List<MindDetails>> GetRepeatDefaulters()
        {
            return await itrack.GetRepeatDefaulters();
        }

        /// <summary>
        /// Gets the details of selected mind
        /// </summary>
        /// <returns> details like CmRecords, GlcSwipes, LeadDetails, Defaulters Count, Residence </returns>
        [HttpGet]
        [Route("api/MindsDb/GetMind/{Mid}")]
        public async Task<MindDetails> GetMind(string Mid) {
            return await itrack.GetMind(Mid);
        }

        /// <summary>
        /// Post the data from the excel file
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/MindsDb/PostMindDetails")]
        public async Task PostMindDetails([FromBody] BindingList<ExcelData> list)
        {
            try
            {
                await itrack.PostMindDetails(list);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new HttpResponseException(HttpStatusCode.NotAcceptable);

            }
        }
        [HttpPost]
        [Route("api/MindsDb/PostExcusedMindsDetails")]
        public async Task PostExcusedMindDetails([FromBody] BindingList<ExcusedMinds> list)
        {
            try
            {
                await itrack.PostExcusedMinds(list);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new HttpResponseException(HttpStatusCode.NotAcceptable);

            }
        }
        [HttpGet]
        [Route("api/MindsDb/GetLastWeekDefaulters")]
        public async Task<List<MindDetails>> GetLastWeekDefaulters()
        {
            try
            {
                return await itrack.GetLastWeekDefaulters();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new HttpResponseException(HttpStatusCode.NotAcceptable);

            }
        }
        [HttpGet]
        [Route("api/MindsDb/GetLastThreeDaysDefaulters")]
        public async Task<List<MindDetails>> GetLastThreeDaysDefaulters()
        {
            try
            {
                return await itrack.GetLastThreeDaysDefaulters();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new HttpResponseException(HttpStatusCode.NotAcceptable);

            }
        }
        [HttpGet]
        [Route("api/MindsDb/GetLastMonthDefaulters")]
        public async Task<List<MindDetails>> GetLastMonthDefaulters()
        {
            try
            {
                return await itrack.GetLastMonthDefaulters();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new HttpResponseException(HttpStatusCode.NotAcceptable);

            }
        }
        [HttpGet]
        [Route("api/MindsDb/GetLastThreeMonthsDefaulters")]
        public async Task<List<MindDetails>> GetLastThreeMonthsDefaulters()
        {
            try
            {
                return await itrack.GetLastThreeMonthsDefaulters();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new HttpResponseException(HttpStatusCode.NotAcceptable);

            }
        }
        [HttpGet]
        [Route("api/MindsDb/GetThresholdDefaulters")]
        public async Task<List<MindDetails>> GetThresholdDefaulters()
        {
            try
            {
                return await itrack.GetThresholdDefaulters();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new HttpResponseException(HttpStatusCode.NotAcceptable);

            }

        }
        [HttpPost]
        [Route("api/MindsDb/PostSettings")]
        public async Task PostSettings(Settings obj)
        {
            try
            {
                await itrack.PostSettingsDetails(obj);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new HttpResponseException(HttpStatusCode.NotAcceptable);

            }
        }
        [HttpGet]
        [Route("api/MindsDb/GetSettings/{category}")]
        public async Task<Settings> GetSettings(string category)
        {
            return await itrack.GetSettingsDetails(category);
        }

        [HttpPut]
        [Route("api/MindsDb/UploadImages")]
        public async Task<int?> PostImage()
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                return (await itrack.PostImage(HttpContext.Current.Request));
            }
        }

        [HttpPost]
        [Route("api/MindsDb/PostCMDetails")]
        public async Task PostCMDetails([FromBody] BindingList<CMExcel> list)
        {
            try
            {
                await itrack.PostCMDetails(list);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new HttpResponseException(HttpStatusCode.NotAcceptable);

            }
        }

    }
}
