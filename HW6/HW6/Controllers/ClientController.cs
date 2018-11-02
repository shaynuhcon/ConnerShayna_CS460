using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web.Mvc;
using HW6.DAL;
using HW6.Models.ViewModels;

namespace HW6.Controllers
{
    public class ClientController : Controller
    {
        private readonly WideWorldImportersContext _context;

        public ClientController(WideWorldImportersContext context)
        {
            _context = context;
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(PeopleViewModel model)
        {
            model.PeopleResults = _context.People
                .Where(p => p.FullName.Contains(model.Name))
                .Select(p => new PersonSearchViewModel
                {
                    PersonID = p.PersonID,
                    FullName = p.FullName
                }).ToList();
            _context.Dispose();

            return View(model);
        }

        [HttpGet]
        public ActionResult Get(int id)
        {
            PersonViewModel person;

            var primary = _context.Customers.FirstOrDefault(c => c.PrimaryContactPersonID == id);
            if (primary != null) return RedirectToAction("GetPrimaryContact", new {id});

            person = _context.People
                .Where(p => p.PersonID == id)
                .Select(p => new PersonViewModel
                {
                    FullName = p.FullName,
                    PreferredName = p.PreferredName,
                    PhoneNumber = p.PhoneNumber,
                    FaxNumber = p.FaxNumber,
                    EmailAddress = p.EmailAddress,
                    ValidFrom = SqlFunctions.DateName("month", p.ValidFrom) + " " +
                                SqlFunctions.DateName("day", p.ValidFrom) + ", " +
                                SqlFunctions.DateName("year", p.ValidFrom),
                    Photo = p.Photo
                }).FirstOrDefault();

            _context.Dispose();
            return View(person);
        }

        public ActionResult GetPrimaryContact(int id)
        {
            var primary = _context.Customers.FirstOrDefault(c => c.PrimaryContactPersonID == id);
            
        }
    }
}