using System;
using System.Linq;
using System.Web.Mvc;
using HW8.DAL;
using HW8.Models;
using HW8.Models.ViewModels;

namespace HW8.Controllers
{
    public class BidController : Controller
    {
        public ActionResult Create()
        {
            PopulateDropdownValues();
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateBidViewModel model)
        {
            if (!ModelState.IsValid)
            {
                PopulateDropdownValues();
                return View(model);
            }

            using (var context = new AuctionContext())
            {
                context.Bids.Add(new Bid
                {
                    Price = model.Price,
                    Timestamp = DateTime.Now,
                    ItemId = model.ItemId,
                    BuyerId = model.BuyerId
                });

                context.SaveChanges();
            }

            ItemDetailViewModel detailModel = new ItemDetailViewModel();

            return RedirectToAction("Details", "Item", new { model = detailModel });
        }

        private void PopulateDropdownValues()
        {
            using (var context = new AuctionContext())
            {
                ViewBag.Buyers = context.Buyers.ToList().ToDictionary(x => x.BuyerId, x => x.Name);
                ViewBag.Items = context.Items.ToList().ToDictionary(x => x.ItemId, x => x.Name);
            }
        }
    }
}