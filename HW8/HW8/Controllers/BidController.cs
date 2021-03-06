﻿using System;
using System.Collections.Generic;
using System.Globalization;
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
            // Allow user to bid on item
            PopulateDropdownValues();
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateBidViewModel model)
        {
            // If model validation does not pass, display form with errors
            if (!ModelState.IsValid)
            {
                PopulateDropdownValues();
                return View(model);
            }

            // Add new bid to database
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

            // Take user to item details page which displays all bids
            return RedirectToAction("Details", "Item", new { id = model.ItemId });
        }

        [HttpGet]
        public PartialViewResult BidsByItem(int id)
        {
            // Partial view displaying bids for specific item
            return PartialView("_BidsByItemID", GetBidsByItemId(id));
        }

        public PartialViewResult RecentBids()
        {
            // Partial view displaying top 10 most recent bids
            return PartialView("_RecentBids", GetMostRecentBids());
        }

        private IEnumerable<ListBidViewModel> GetBidsByItemId(int id)
        {
            List<Bid> bids = new List<Bid>();
            List<ListBidViewModel> model = new List<ListBidViewModel>();

            // Get bids by item ID
            using (var context = new AuctionContext())
            {
                bids = context.Bids.Where(b => b.ItemId == id).ToList();
                
                // Convert list of Bid to list of ListBidViewModel
                foreach (var bid in bids)
                {
                    model.Add(new ListBidViewModel
                    {
                        ItemId = bid.ItemId,
                        Timestamp = bid.Timestamp.ToString("dd MMM yyyy hh:mm tt"),
                        Price = bid.Price,
                        BuyerName = context.Buyers.FirstOrDefault(b => b.BuyerId == bid.BuyerId)?.Name
                    });
                }
            }

            // Order descending by price
            model = model.OrderByDescending(p => p.Price).ToList();
            return model;
        }

        private IEnumerable<ListBidViewModel> GetMostRecentBids()
        {
            List<Bid> bids = new List<Bid>();
            List<ListBidViewModel> model = new List<ListBidViewModel>();

            using (var context = new AuctionContext())
            {
                // Get most recent 10 bids 
                bids = context.Bids.OrderByDescending(b => b.Timestamp).Take(10).ToList();

                // Convert list of Bid to list of ListBidViewModel
                foreach (var bid in bids)
                {
                    ListBidViewModel listBid = new ListBidViewModel();

                    listBid.ItemId = bid.ItemId;
                    listBid.ItemName = context.Items.FirstOrDefault(i => i.ItemId == bid.ItemId)?.Name;
                    listBid.Price = bid.Price;;
                    listBid.BuyerName = context.Buyers.FirstOrDefault(b => b.BuyerId == bid.BuyerId)?.Name;

                    if (bid.Timestamp.Date == DateTime.Today) listBid.Timestamp = bid.Timestamp.ToString("hh:mm tt");
                    else listBid.Timestamp = bid.Timestamp.ToString("dd MMM yyyy hh:mm tt");

                    model.Add(listBid);
                }
            }

            return model;
        }

        private void PopulateDropdownValues()
        {
            // Dropdown values for Buyer and Items 
            using (var context = new AuctionContext())
            {
                ViewBag.Buyers = context.Buyers.ToList().ToDictionary(x => x.BuyerId, x => x.Name);
                ViewBag.Items = context.Items.ToList().ToDictionary(x => x.ItemId, x => x.Name);
            }
        }
    }
}