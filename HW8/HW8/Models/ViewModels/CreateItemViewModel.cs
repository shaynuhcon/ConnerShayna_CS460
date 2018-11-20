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

        [Required(ErrorMessage = "Seller is required")]
        [DisplayName("Seller")]
        public int SellerId { get; set; }
    }
}