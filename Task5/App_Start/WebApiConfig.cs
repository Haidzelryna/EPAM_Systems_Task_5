using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Task5
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{Id}",
                defaults: new { id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
               name: "SalesWebApi",
               routeTemplate: "api/SalesWebApi/{loadOptions}"//,
                                                             //defaults: new { id = RouteParameter.Optional}
               );
        }
    }
}
