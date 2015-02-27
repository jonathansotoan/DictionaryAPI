using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Dictionary.Api.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors();
            //config.EnableCors(new EnableCorsAttribute("www.example.com,www.example2.com", "*", "get,post"));//allows CORS for the whole web api

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { controller = "Words", id = RouteParameter.Optional }
            );

            // Error policy
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.LocalOnly;
        }
    }
}
