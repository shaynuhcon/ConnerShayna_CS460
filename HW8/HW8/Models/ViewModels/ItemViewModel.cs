using System.ComponentModel;

namespace HW8.Models.ViewModels
{
    public class ItemViewModel
    {
        [DisplayName("Item ID")]
        public int ItemId { get; set; }

        [DisplayName("Item Name")]
        public string Name { get; set; }

        [DisplayName("Item Description")]
        public string Description { get; set; }

        [DisplayName("Seller Name")]
        public string SellerName { get; set; }
    }
}