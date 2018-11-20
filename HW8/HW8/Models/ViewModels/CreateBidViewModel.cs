using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HW8.Models.ViewModels
{
    public class CreateBidViewModel
    {
        [Required]
        [DisplayName("Bid Amount")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [DisplayName("Item")]
        public int ItemId { get; set; }

        [Required]
        [DisplayName("Buyer")]
        public int BuyerId { get; set; }
    }
}