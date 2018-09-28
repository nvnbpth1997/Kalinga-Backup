using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Tracking.DataAccessLayer.DbContext;
using Tracking.Entities;

namespace ITracking.Bussiness
{
    public interface ITrackingBusiness
    {
        /// <summary>
        /// Method to send email to defaulters, leads and PF.
        /// </summary>
        /// <returns></returns>
        Task SendEmails();
        /// <summary>
        /// Sends reset code for user to reset their password mail to requested one.
        /// </summary>
        /// <param name="givenEmail"></param>
        /// <param name="newCode"></param>
        /// <returns></returns>
        Task SendNewCode(string givenEmail, string newCode);
        /// <summary>
        /// Method to get the LateSwipes details.
        /// </summary>
        /// <returns></returns>
        Task<List<MindDetails>> GetLateSwipes();
        /// <summary>
        /// Method to get the NotSwipe Details
        /// </summary>
        /// <returns></returns>
        Task<List<MindDetails>> GetNotSwipes();
        /// <summary>
        /// Method to get not swipe details.
        /// </summary>
        /// <returns></returns>
        Task<List<MindDetails>> GetOnTimeSwipes();
        /// <summary>
        /// Method to get the repeat defaulters details.
        /// </summary>
        /// <returns></returns>
        Task<List<MindDetails>> GetRepeatDefaulters();
        /// <summary>
        /// Method to get detail of the selected mind.
        /// </summary>
        /// <param name="Mid"></param>
        /// <returns></returns>
        Task<MindDetails> GetMind(string Mid);
        /// <summary>
        /// Method to post data of swipes from excel to db.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        Task PostMindDetails(BindingList<ExcelData> list);
        /// <summary>
        /// Method to post the data for excused absences from excel to db.
        /// </summary>
        /// <returns></returns>
        Task PostExcusedMinds(BindingList<ExcusedMinds> list);      
        /// <summary>
        /// To send alert mails to all campus minds when count of total defaulters incresded by certain no.
        /// </summary>
        /// <returns></returns>
        Task AlertMail();
        /// <summary>
        /// Method to get details of last week repeated defaulters.
        /// </summary>
        /// <returns></returns>
        Task<List<MindDetails>> GetLastWeekDefaulters();
        /// <summary>
        /// Method to get details of last Three Days repeated defaulters.
        /// </summary>
        /// <returns></returns>
        Task<List<MindDetails>> GetLastThreeDaysDefaulters();
        /// <summary>
        /// Method to get details of last Month repeated defaulters.
        /// </summary>
        /// <returns></returns>
        Task<List<MindDetails>> GetLastMonthDefaulters();
        /// <summary>
        /// Method to get details of last threee month repeated defaulters.
        /// </summary>
        /// <returns></returns>
        Task<List<MindDetails>> GetLastThreeMonthsDefaulters();
        /// <summary>
        /// Method to get details of minds who are defaulters of more than three times.
        /// </summary>
        /// <returns></returns>
        Task<List<MindDetails>> GetThresholdDefaulters();
        /// <summary>
        /// To post the settings values.
        /// </summary>
        /// <returns></returns>
        Task PostSettingsDetails(Settings obj);
        /// <summary>
        /// To get the settings values of prefered category(C1 or IMTS).
        /// </summary>
        /// <returns></returns>
        Task<Settings> GetSettingsDetails(string category);
        Task<int> PostImage(HttpRequest httpRequest);

        Task PostCMDetails(BindingList<CMExcel> list);
    }
}
