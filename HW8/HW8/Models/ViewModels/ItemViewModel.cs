using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HW8.Models.ViewModels
{
    public class ItemViewModel
    {
        [DisplayName("Item ID")]
        public int ItemId { get; set; }

        [Required]
        [DisplayName("Item Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Item Description")]
        public string Description { get; set; }

        [Required]
        [DisplayName("Seller Name")]
        public string SellerName { get; set; }
    }
}