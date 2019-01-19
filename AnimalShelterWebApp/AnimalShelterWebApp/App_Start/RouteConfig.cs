using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AnimalShelterWebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            #region Home
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}", //id to może być cokolwiek
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "SetAbout",
                url: "Home/SetAbout"
               // defaults: new { action =UrlParameter.Optional, id = UrlParameter.Optional }
            );
            #endregion

            #region Hello
            routes.MapRoute(
                name: "StartHello",
                url: "Hello"

            );
            routes.MapRoute(
                name: "Subscribe",
                url: "Hello/Subscribe"
               

            );
            #endregion

            #region Event
            routes.MapRoute(
               name: "StartEvent",
               url: "Event"
           );
            #endregion
            #region Hotel
            routes.MapRoute(
               name: "StartHotel",
               url: "Hotel"
           );
            #endregion
            #region Storage
            routes.MapRoute(
               name: "StartStorage",
               url: "Storage"
           );
            #endregion
        }
    }
}
