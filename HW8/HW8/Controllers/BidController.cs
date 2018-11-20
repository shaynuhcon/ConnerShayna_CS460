using System;
using System.Collections.Generic;
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

            return RedirectToAction("Details", "Item", new { id = model.ItemId });
        }

        public PartialViewResult Bids(int id)
        {

            return PartialView("_Bids", GetAllBids());
        }

        private IEnumerable<ListBidViewModel> GetAllBids()
        {
            List<Bid> bids = new List<Bid>();
            List<ListBidViewModel> model = new List<ListBidViewModel>();

            // Get all available bids
            using (var context = new AuctionContext())
            {
                bids = context.Bids.ToList();


                // Convert list of Bid to list of ListBidViewModel
                foreach (var bid in bids)
                {
                    model.Add(new ListBidViewModel
                    {
                        Timestamp = bid.Timestamp,
                        Price = bid.Price,
                        BuyerName = context.Buyers.FirstOrDefault(b => b.BuyerId == bid.BuyerId)?.Name
                    });
                }
            }

            // Order descending by price
            model = model.OrderByDescending(p => p.Price).ToList();
            return model;
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