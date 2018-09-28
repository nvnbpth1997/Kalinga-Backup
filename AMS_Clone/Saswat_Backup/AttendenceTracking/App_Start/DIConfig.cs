using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;
using ITracking.Bussiness;
using Tracking.Bussiness;
using Tracking.DataAccessLayer.IService.Respository;
using Tracking.DataAccessLayer.Service.Respository;
using System.Web.Http;
using Unity.AspNet.WebApi;

namespace AttendenceTracking.App_Start
{
    public class DIConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IServiceLayer, ServiceLayer>();
            container.RegisterType<ITrackingBusiness, TrackingBusiness>();
           // container.RegisterType<IBookingService, BookingService>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}