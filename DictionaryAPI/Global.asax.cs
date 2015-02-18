using System.Web.Http;
using System.Web.Optimization;
using System.Web.Routing;
using DictionaryAPI.App_Start;
using DictionaryApi.DataAccess;
using System.Data.Entity;
using System.Web.Mvc;

namespace DictionaryAPI
{
    public class DictionaryApiGlobalConfig : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer<DictionaryContext>(new DictionaryInitializer());
            FormatterConfig.Format(GlobalConfiguration.Configuration.Formatters);
        }
    }
}
