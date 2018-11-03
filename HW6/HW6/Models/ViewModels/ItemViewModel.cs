using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HW6.Models.ViewModels
{
    public class ItemViewModel
    {
        [DisplayName("Stock Item ID")]
        public int StockItemID { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Line profit")]
        [DataType(DataType.Currency)]
        public decimal LineProfit { get; set; }

        [DisplayName("Sales person")]
        public string SalesPerson { get; set; }
    }
}