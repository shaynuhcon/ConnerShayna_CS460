using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HW8.Models.ViewModels
{
    public class CreateItemViewModel
    {
        [Required]
        [DisplayName("Item Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Item Description")]
        public string Description { get; set; }

        [DisplayName("Seller Name")]
        public string SellerName { get; set; }

        [DisplayName("Seller ID")]
        public int SellerId { get; set; }
    }
}