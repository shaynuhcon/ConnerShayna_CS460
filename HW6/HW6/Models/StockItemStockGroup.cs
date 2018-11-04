using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HW6.Models
{
    [Table("Warehouse.StockItemStockGroups")]
    public partial class StockItemStockGroup
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StockItemStockGroupID { get; set; }

        public int StockItemID { get; set; }

        public int StockGroupID { get; set; }

        public int LastEditedBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime LastEditedWhen { get; set; }

        public virtual Person Person { get; set; }

        public virtual StockGroup StockGroup { get; set; }

        public virtual StockItem StockItem { get; set; }
    }
}
