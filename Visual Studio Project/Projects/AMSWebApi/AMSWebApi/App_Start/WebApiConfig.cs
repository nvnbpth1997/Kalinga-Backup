using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AMSWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors(new EnableCorsAttribute("http://localhost:4200", headers: "*", methods: "*"));
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

           config.Routes.MapHttpRoute(
           name: "ApiBySwipe",
           routeTemplate: "api/{controller}/{action}/{value}",
           defaults: new { value = RouteParameter.Optional }
           );

           //config.Routes.MapHttpRoute(
           //name: "ApiFindMind",
           //routeTemplate: "api/{controller}/{id}",
           //defaults: new { id = RouteParameter.Optional }
           //);

            config.Routes.MapHttpRoute(
            name: "ApiDefaulter",
            routeTemplate: "api/{controller}/ByDefaulter"
         );

            config.Routes.MapHttpRoute(
            name: "ApiDefaulterTrack",
            routeTemplate: "api/{controller}/ByDefaulterTrack/{value}",
            defaults: new { value = RouteParameter.Optional }
         );

           config.Routes.MapHttpRoute(
           name: "ApiDefaulterByDateTrack",
           routeTemplate: "api/{controller}/ByDefaulterDateTrack/{from}/{to}",
           defaults: new { from = RouteParameter.Optional, to = RouteParameter.Optional }
        );

          config.Routes.MapHttpRoute(
          name: "ApiDownload",
          routeTemplate: "api/Images/Download/{mid}",
          defaults: new { mid = RouteParameter.Optional }
       );

        }
    }
}
