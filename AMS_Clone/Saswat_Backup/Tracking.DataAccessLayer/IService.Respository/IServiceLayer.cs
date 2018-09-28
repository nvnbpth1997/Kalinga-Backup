using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracking.DataAccessLayer.DbContext;
using Tracking.Entities;

namespace Tracking.DataAccessLayer.IService.Respository
{
    public interface IServiceLayer
    {
        //method to post excused minds from excel to db
        Task PostExcusedMinds(BindingList<ExcuseData> excusedList);
        //method to fetch all excused minds
        Task<List<ExcuseData>> GetExcusedMinds();
        /// <summary>
        /// Method to post mind swipe details from excel to db. C:\Users\M1046670\Desktop\Sprint2\Saswat_Backup\Tracking.Entities\ExcelData.cs
        /// </summary>
        /// <param name="glcList"></param>
        /// <returns></returns>
        Task PostMindDetails(BindingList<GlcSwipe> glcList);
        /// <summary>
        /// Method to get defaulter list like lateswipe, notswipe with their lead details.
        /// </summary>
        /// <param name="increment"></param>
        /// <returns></returns>
        Task<List<Tuple<CmRecords,GlcSwipe,LeadDetails>>[]> GetDefaulters(bool increment);
        /// <summary>
        /// Method to fetch all lateswipes details of minds from db.
        /// </summary>
        /// <returns></returns>
        Task<List<MindDetails>> GetLateSwipes();
        /// <summary>
        /// Method to fetch all notswipes details of minds from db.
        /// </summary>
        /// <returns></returns>
        Task<List<MindDetails>> GetNotSwipes();
        /// <summary>
        /// Method to fetch all swipesontime details of minds from db.
        /// </summary>
        /// <returns></returns>
        Task<List<MindDetails>> GetOnTimeSwipes();
        /// <summary>
        /// Method to fetch selected mind details from db.
        /// </summary>
        /// <param name="Mid"></param>
        /// <returns></returns>
        Task<MindDetails> GetMind(string Mid);
        /// <summary>
        /// Method to delete mind swipe detail.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        Task DeleteWrongEntry(string date);
        /// <summary>
        /// Method to get repeat defaulters details
        /// </summary>
        /// <returns></returns>
        Task<List<MindDetails>> GetRepeatDefaulters();
        /// <summary>
        /// Get PF details from db.
        /// </summary>
        /// <returns></returns>
        Task<Admin> GetPF();
        /// <summary>
        /// Get Holiday Dates from database. 
        /// </summary>
        /// <returns></returns>
        Task<List<DateTime>> GetHolidays();
        /// <summary>
        /// Get Weekly Defaulters count. 
        /// </summary>
        /// <returns></returns>
        Task<List<GlcSwipe>> GetWeeklyDefaultersCount();
        /// <summary>
        /// Get the list of last swipe detail.
        /// </summary>
        /// <returns></returns>
        Task<List<SwipeTrack>> GetLastSwipeDetails();
        /// <summary>
        /// Add the last swipe details.
        /// </summary>
        /// <param name="swipetrack"></param>
        /// <returns></returns>
        Task AddLastSwipe(SwipeTrack swipetrack);
        /// <summary>
        /// Updates the existing last swipe details.
        /// </summary>
        /// <param name="swipetrack"></param>
        /// <returns></returns>
        Task UpdateLastSwipe(SwipeTrack swipetrack);
        /// <summary>
        /// Get the Complete CmRecords
        /// </summary>
        /// <returns></returns>
        Task <List<CmRecords>> GetCmRecords();
        /// <summary>
        /// To get the weekly defaulters.
        /// </summary>
        /// <returns></returns>
        Task<List<GlcSwipe>> GetGLCSwipesLastWeek();
        /// <summary>
        /// To get defaulters of last Three Days.
        /// </summary>
        /// <returns></returns>
        Task<List<GlcSwipe>> GetGLCSwipesLastThreeDays();
        /// <summary>
        /// To get defaulters of last Month.
        /// </summary>
        /// <returns></returns>
        Task<List<GlcSwipe>> GetGLCSwipesLastMonth();
        /// <summary>
        /// To get the defaulters of last three Months.
        /// </summary>
        /// <returns></returns>
        Task<List<GlcSwipe>> GetGLCSwipesLastThreeMonths();
        /// <summary>
        /// To get the defaulters who are repeated more than three times.
        /// </summary>
        /// <returns></returns>
        Task<List<MindDetails>> GetGLCThresholdDefaulters();
        /// <summary>
        /// To get all the defaulters Who swiped late.
        /// </summary>
        /// <returns></returns>
        Task<List<MindDetails>> GetLateSwipesAll();
        /// <summary>
        /// To get all the defaulters who did not swipe.
        /// </summary>
        /// <returns></returns>
        Task<List<MindDetails>> GetNotSwipesAll();
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
        Task UndoSwipeTrackUpdate();
        Task<int> PostImage(string imageURL, string imageName);

        Task GetCMRecords(CmRecords cm);
    }
}
