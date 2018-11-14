using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using HW8.DAL;
using HW8.Models;
using HW8.Models.ViewModels;

namespace HW8.Controllers
{
    public class ItemController : Controller
    {
        public ActionResult Index()
        {
            return View("List", GetAllItems());
        }

        public ActionResult Create()
        {
            ViewBag.Sellers = null;

            using (var context = new AuctionContext())
            {
                ViewBag.Sellers = context.Sellers.ToList().ToDictionary(x => x.SellerId, x => x.Name);
            }

            return View();
        }
        
        [HttpPost]
        public ActionResult Create(CreateItemViewModel model)
        {
            using (var context = new AuctionContext()) 
            {
                context.Items.Add(new Item
                {
                    Name = model.Name,
                    Description = model.Description,
                    SellerId = model.SellerId
                });

                context.SaveChanges();
            }

            return View("List", GetAllItems());
        }

        public ActionResult Details()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            using (var context = new AuctionContext())
            {
                var item = context.Items.FirstOrDefault(i => i.ItemId == id);
                context.Items.Remove(item);
                context.SaveChanges();
            }

            return View("List", GetAllItems());
        }

        private IEnumerable<ListItemViewModel> GetAllItems()
        {
            List<Item> items = new List<Item>();
            List<ListItemViewModel> model = new List<ListItemViewModel>();
            
            // Get all available items
            using (var context = new AuctionContext())
            {
                items = context.Items.ToList();


                // Convert list of Item to list of ItemViewModel
                foreach (var item in items)
                {
                    model.Add(new ListItemViewModel
                    {
                        ItemId = item.ItemId,
                        Name = item.Name,
                        Description = item.Description,
                        SellerName = context.Sellers.FirstOrDefault(s => s.SellerId == item.SellerId)?.Name
                    });
                }
            }

            return model;
        }
    }
}