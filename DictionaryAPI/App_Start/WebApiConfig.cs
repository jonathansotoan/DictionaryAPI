using System.Web.Http;

namespace DictionaryAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name         : "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults     : new { controller = "Dictionary", id = RouteParameter.Optional }
            );

            // Error policy
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.LocalOnly;
        }
    }
}
