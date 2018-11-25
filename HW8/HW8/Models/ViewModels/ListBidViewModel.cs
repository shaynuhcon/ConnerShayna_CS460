using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HW8.Models.ViewModels
{
    public class ListBidViewModel
    {
        [DisplayName("Item ID")]
        public int? ItemId { get; set; }

        [DisplayName("Item Name")]
        public string ItemName { get; set; }

        [DisplayName("Buyer Name")]
        public string BuyerName { get; set; }

        public string Timestamp { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}