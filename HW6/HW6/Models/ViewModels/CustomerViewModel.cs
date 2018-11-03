using System.Collections.Generic;

namespace HW6.Models.ViewModels
{
    public class CustomerViewModel
    {
        public PersonViewModel Person { get; set; }

        public CompanyViewModel Company { get; set; }

        public PurchaseViewModel Purchases { get; set; }

        public IEnumerable<ItemViewModel> Items { get; set; }
    }
}