using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using WebAPI.Models.Handlers;
using Utilities;
using System;

namespace WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandlers());
            config.MessageHandlers.Add(new Models.Handlers.MessageHandlers());
            config.MapHttpAttributeRoutes();

            //Level1 Routes
            Type type = typeof(Constants.ControllerLevels.Level1);
            foreach (var item in type.GetProperties())
            {
                string[] properties = item.GetValue(null).ToString().Split(',');
                config.Routes.MapHttpRoute(
                    name: "Level1_" + properties[0] + "_" + properties[1],
                    routeTemplate: "api/" + properties[0] + "/{" + properties[2] + "}/" + properties[1] + "/{id}",
                    defaults: new { controller = properties[1], id = RouteParameter.Optional }
                   );
            }


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
