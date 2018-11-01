using System.Linq;
using System.Web.Mvc;
using HW6.DAL;
using HW6.Models.ViewModels;

namespace HW6.Controllers
{
    public class ClientController : Controller
    {
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(PeopleViewModel model)
        {
            using (var context = new WideWorldImportersContext())
            {
                model.PeopleResults = context.People
                    .Where(p => p.FullName.Contains(model.Name))
                    .Select(p => new PersonSearchViewModel
                    {
                        PersonID = p.PersonID,
                        FullName = p.FullName
                    }).ToList();
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Get(int id)
        {
            PersonViewModel person;

            using (var context = new WideWorldImportersContext())
            {
                person = context.People
                    .Where(p => p.PersonID == id)
                    .Select(p => new PersonViewModel
                    {
                        FullName = p.FullName,
                        PreferredName = p.PreferredName,
                        PhoneNumber = p.PhoneNumber,
                        FaxNumber = p.FaxNumber,
                        EmailAddress = p.EmailAddress,
                        ValidFrom = p.ValidFrom,
                        Photo = p.Photo
                    }).FirstOrDefault();
            }

            return View(person);
        }
    }
}