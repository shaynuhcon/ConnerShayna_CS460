using System.Collections.Generic;

namespace HW6.Models.ViewModels
{
    // Main ViewModel for Customer Dashboard feature
    public class CustomerViewModel
    {
        // Same ViewModel used for first feature which will also be used here
        public PersonViewModel Person { get; set; }

        // ViewModel to hold company information 
        public CompanyViewModel Company { get; set; }

        // ViewModel to hold information regarding purchase history
        public PurchaseViewModel Purchases { get; set; }

        // List of items that that are most profitable
        public IEnumerable<ItemViewModel> Items { get; set; }
    }
}