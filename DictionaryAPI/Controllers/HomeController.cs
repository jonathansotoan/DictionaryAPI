using System.Web.Mvc;

namespace DictionaryApi.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}