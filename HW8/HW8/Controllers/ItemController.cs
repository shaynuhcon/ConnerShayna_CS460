using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using HW8.DAL;
using HW8.Models.ViewModels;

namespace HW8.Controllers
{
    public class ItemController : Controller
    {
        private readonly AuctionContext _context = new AuctionContext();
        public ActionResult Index()
        {
            // Get all available items
            var items = _context.Items.ToList();
            var model = new List<ItemViewModel>();

            // Convert list of Item to list of ItemViewModel
            foreach (var item in items)
            {
                model.Add(new ItemViewModel
                {
                    ItemId = item.ItemId,
                    Name = item.Name,
                    Description = item.Description,
                    SellerName = _context.Sellers.FirstOrDefault(s => s.SellerId == item.SellerId)?.Name
                });
            }

            _context.Dispose();
        
            return View("List", model);
        }

        public ActionResult Create()
        {
            return View();
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
            return View();
        }
    }
}