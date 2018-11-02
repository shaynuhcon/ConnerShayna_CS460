using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web.Mvc;
using HW6.DAL;
using HW6.Models.ViewModels;

namespace HW6.Controllers
{
    public class ClientController : Controller
    {
        private readonly WideWorldImportersContext _context = new WideWorldImportersContext();

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
            var primary = _context.Customers.FirstOrDefault(c => c.PrimaryContactPersonID == id);

            if (primary != null)
            {
                _context.Dispose();
                return RedirectToAction("GetPrimaryContact", new {id});
            }

            PersonViewModel person = _context.People
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
            var customer = new CustomerViewModel();

            customer.Company = _context.Customers
                .Where(c => c.PrimaryContactPersonID == id)
                .Select(c => new CompanyViewModel
                {
                    CompanyName = c.CustomerName,
                    AccountOpened = SqlFunctions.DateName("month", c.AccountOpenedDate) + " " +
                                    SqlFunctions.DateName("day", c.AccountOpenedDate) + ", " +
                                    SqlFunctions.DateName("year", c.AccountOpenedDate),
                    FaxNumber = c.FaxNumber,
                    PhoneNumber = c.PhoneNumber,
                    Website = c.WebsiteURL
                }).FirstOrDefault();
            
            customer.Purchases = new PurchaseViewModel
            {
                TotalOrders = _context.Customers.Where(c => c.PrimaryContactPersonID == id).SelectMany(c => c.Orders)
                    .ToList().Count,
                TotalGrossSales = _context.Customers
                    .Where(c => c.PrimaryContactPersonID == id)
                    .SelectMany(c => c.Orders
                        .SelectMany(o => o.Invoices
                            .SelectMany(i => i.InvoiceLines.Select(il => il.ExtendedPrice)))).ToList().Sum(),
                TotalProfit = _context.Customers
                    .Where(c => c.PrimaryContactPersonID == id)
                    .SelectMany(c => c.Orders
                        .SelectMany(o => o.Invoices
                            .SelectMany(i => i.InvoiceLines.Select(il => il.LineProfit)))).ToList().Sum()
            };

            _context.Dispose();
            return View("CustomerDashboard", customer);
        }
    }
}