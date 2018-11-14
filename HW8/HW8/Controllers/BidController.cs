using System.Web.Mvc;

namespace HW8.Controllers
{
    public class BidController : Controller
    {
        public ActionResult Index()
        {
            return View("Create");
        }
    }
}