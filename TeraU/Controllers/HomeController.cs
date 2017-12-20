using System.Web.Mvc;

namespace TeraU.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AnotherLink()
        {
            return View("View");
        }
    }
}
