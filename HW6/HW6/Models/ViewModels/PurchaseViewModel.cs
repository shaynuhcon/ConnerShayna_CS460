using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HW6.Models.ViewModels
{
    public class PurchaseViewModel
    {
        [DisplayName("Total orders")]
        public int TotalOrders { get; set; }

        [DisplayName("Total gross sales")]
        [DataType(DataType.Currency)]
        public decimal TotalGrossSales { get; set; }

        [DisplayName("Total profit")]
        [DataType(DataType.Currency)]
        public decimal TotalProfit { get; set; }
    }
}