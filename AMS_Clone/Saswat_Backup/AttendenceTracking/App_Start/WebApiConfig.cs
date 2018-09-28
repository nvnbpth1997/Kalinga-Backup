using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AttendenceTracking.Unity;
using ITracking.Bussiness;
using Tracking.Bussiness;
using Unity;
using Unity.Lifetime;
using System.Web.Http.Cors;

namespace AttendenceTracking
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<ITrackingBusiness, TrackingBusiness>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
            // Web API routes
           // var cors = new EnableCorsAttribute(origins: "http://localhost:4200", headers: "*", methods: "*");
           // config.EnableCors();
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ////config.Routes.MapHttpRoute(
            ////    name: "OnTimeSwipeApi",
            ////    routeTemplate: "api/{controller}/GetOnTimeSwipe"
               
            //);

        }
    }
}
