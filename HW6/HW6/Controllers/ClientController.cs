using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web.Mvc;
using HW6.DAL;
using HW6.Models.ViewModels;

namespace HW6.Controllers
{
    public class ClientController : Controller
    {
        private readonly WorldWideImportersContext _context = new WorldWideImportersContext();

        public ActionResult Search()
        {
            // Return view where user can search for person by name
            return View();
        }

        [HttpPost]
        public ActionResult Search(PeopleViewModel model)
        {
            // Search for any person whose name contains input provided by user 
            // then assign to view model
            model.PeopleResults = _context.People
                .Where(p => p.FullName.Contains(model.Name))
                .Select(p => new PersonSearchViewModel
                {
                    PersonID = p.PersonID,
                    FullName = p.FullName
                }).ToList();

            _context.Dispose();

            // Return view with search results
            return View(model);
        }

        [HttpGet]
        public ActionResult Get(int id)
        {
            // Check if Person is a PrimaryContactPerson in Customer table
            var primary = _context.Customers.FirstOrDefault(c => c.PrimaryContactPersonID == id);

            // If Person is PrimaryContactPerson, redirect to get full Customer profile
            if (primary != null)
            {
                _context.Dispose();
                return RedirectToAction("GetPrimaryContact", new {id});
            }

            // Get Person values needed for profile
            PersonViewModel person = _context.People
                .Where(p => p.PersonID == id)
                .Select(p => new PersonViewModel
                {
                    FullName = p.FullName,
                    PreferredName = p.PreferredName,
                    PhoneNumber = p.PhoneNumber,
                    FaxNumber = p.FaxNumber,
                    EmailAddress = p.EmailAddress,
                    // SqlFunctions used to format how date will be displayed
                    ValidFrom = SqlFunctions.DateName("month", p.ValidFrom) + " " +
                                SqlFunctions.DateName("day", p.ValidFrom) + ", " +
                                SqlFunctions.DateName("year", p.ValidFrom),
                    Photo = p.Photo
                }).FirstOrDefault();

            _context.Dispose();

            // Return view with results for person
            return View(person);
        }

        // Method for full customer sales dashboard
        public ActionResult GetPrimaryContact(int id)
        {
            var customer = new CustomerViewModel();

            // Get Person data
            customer.Person = _context.People
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

            // Get Company data
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
                    Website = c.WebsiteURL,
                    // The following 3 variables are used for real-time map on results page
                    DeliveryLocation = c.DeliveryLocation,
                    City = c.City.CityName,
                    State =  c.City.StateProvince.StateProvinceName
                }).FirstOrDefault();

            // Get data on invoice purchase amounts
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

            // Get most profitable items from this customer
            int customerId = _context.Customers.FirstOrDefault(c => c.PrimaryContactPersonID == id).CustomerID;

            customer.Items = _context.Invoices.Join(_context.InvoiceLines, i => i.InvoiceID, il => il.InvoiceID,
                    (i, il) => new {Invoice = i, InvoiceLine = il})
                .Where(x => x.Invoice.CustomerID == customerId)
                .OrderByDescending(il => il.InvoiceLine.LineProfit)
                .Take(10)
                .Select(item => new ItemViewModel
                {
                    StockItemID = item.InvoiceLine.StockItemID,
                    Description = item.InvoiceLine.Description,
                    LineProfit = item.InvoiceLine.LineProfit,
                    SalesPerson = item.Invoice.Person4.FullName
                }).ToList();

            _context.Dispose();

            return View("CustomerDashboard", customer);
        }
    }
}
