﻿using System.Collections.Generic;
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
            // Display page with list of items
            return View("List", GetAllItems());
        }

        public ActionResult Create()
        {
            // Allow user to auction new item
            PopulateDropdownValues();
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(CreateItemViewModel model)
        {
            // If model validation does not pass, display form with errors
            if (!ModelState.IsValid)
            {
                PopulateDropdownValues();
                return View(model);
            }

            // Add new item to database 
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

            // Display page with list of items including newly added item
            return View("List", GetAllItems());
        }

        public ActionResult Details(int id)
        {
            var model = new ListItemViewModel();

            // Get item details for specific item
            using (var context = new AuctionContext())
            {
                var item = context.Items.FirstOrDefault(i => i.ItemId == id);
                model.ItemId = id;
                model.Name = item.Name;
                model.Description = item.Description;
                model.SellerName = context.Sellers.FirstOrDefault(s => s.SellerId == item.SellerId)?.Name;
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            PopulateDropdownValues();
            EditItemViewModel model = new EditItemViewModel();

            // Get existing values for given ItemID 
            using (var context = new AuctionContext())
            {
                var item = context.Items.FirstOrDefault(i => i.ItemId == id);
                model.ItemId = id;
                model.Description = item.Description;
                model.Name = item.Name;
                model.SellerId = item.SellerId;
            }
            
            // Display page with existing item values for user to edit
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditItemViewModel model)
        {
            // If model validation does not pass, display form with errors
            if (!ModelState.IsValid)
            {
                PopulateDropdownValues();
                return View(model);
            }

            // Get item and update existing values with new/given values 
            using (var context = new AuctionContext())
            {
                var item = context.Items.FirstOrDefault(i => i.ItemId == model.ItemId);
                item.Description = model.Description;
                item.Name = model.Name;
                item.SellerId = model.SellerId;

                context.SaveChanges();
            }

            // Display page with list of items including newly updated item
            return View("List", GetAllItems());
        }

        public ActionResult Delete()
        {
            // Displays page with list of items as well as Delete link
            return View(GetAllItems());
        }

        public ActionResult DeleteItem(int id)
        {
            // Get item and delete it
            using (var context = new AuctionContext())
            {
                var item = context.Items.FirstOrDefault(i => i.ItemId == id);
                context.Items.Remove(item);
                context.SaveChanges();
            }

            // Display page with list of items excluding recently deleted item
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

        private void PopulateDropdownValues()
        {
            // Get all sellers and save keys/values to dictionary for drop down
            using (var context = new AuctionContext())
            {
                ViewBag.Sellers = context.Sellers.ToList().ToDictionary(x => x.SellerId, x => x.Name);
            }
        }
    }
}