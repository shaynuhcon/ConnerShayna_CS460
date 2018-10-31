using System.Linq;
using System.Web.Mvc;
using HW6.DAL;
using HW6.Models;
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
                model.PeopleResults = context.People.Where(x => x.FullName.Contains(model.Name)).ToList();
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Get(int id)
        {
            Person person;

            using (var context = new WideWorldImportersContext())
            {
                person = context.People.FirstOrDefault(x => x.PersonID == id);
            }

            return View(person);

        }
    }
}