using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using HW5.DAL;
using HW5.Models;

namespace HW5.Controllers
{
    public class RequestController : Controller
    {
        // Display request form
        public ActionResult RequestForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RequestForm(TenantRequest model)
        {
            // Validate model and display errors if needed
            if (!ModelState.IsValid) return View(model);

            // Set Created date for now (when request submitted)
            model.Created = DateTime.Now;

            using (var context = new CampusApartmentsContext())
            {
                // Add/save to table
                context.TenantRequests.Add(model);
                context.SaveChanges();
            }

            // Find request ID for submitted request and return confirmation page
            TenantRequest addedRequest;
            using (var context = new CampusApartmentsContext())
            {
                addedRequest = context.TenantRequests.FirstOrDefault(x => x.LastName == model.LastName);
            }

            return View("ConfirmationPage", addedRequest);
        }

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