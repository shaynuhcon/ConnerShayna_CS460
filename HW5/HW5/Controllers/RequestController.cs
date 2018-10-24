using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using HW5.DAL;
using HW5.Models;

namespace HW5.Controllers
{
    public class RequestController : Controller
    {
        public ActionResult Requests()
        {
            IEnumerable<TenantRequest> requests;

            using (var context = new CampusApartmentsContext())
            {
                requests = context.TenantRequests.ToList();
            }

            return View(requests);
        }
    }
}