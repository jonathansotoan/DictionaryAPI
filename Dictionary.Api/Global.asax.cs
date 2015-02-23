using Dictionary.Api.App_Start;
using Dictionary.DataAccess;
using System.Data.Entity;
using System.Web.Http;

namespace Dictionary.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FormatterConfig.Format(GlobalConfiguration.Configuration.Formatters);
            Database.SetInitializer<DictionaryContext>(new DictionaryInitializer());
        }
    }
}
