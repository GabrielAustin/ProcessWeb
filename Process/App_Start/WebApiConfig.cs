using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace Process
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Session",
                routeTemplate: "sessions/",
                defaults: new {controller = "sessions"}
            );

            config.Routes.MapHttpRoute(
                name: "Task",
                routeTemplate: "tasks/{id}",
                defaults: new { controller = "tasks", id = RouteParameter.Optional}
            );

            config.Routes.MapHttpRoute(
                name: "Environment",
                routeTemplate: "environments/",
                defaults: new { controller = "environments" }
            );
        }
    }
}
