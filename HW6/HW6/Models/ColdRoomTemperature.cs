using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HW6.Models
{
    [Table("Warehouse.ColdRoomTemperatures")]
    public partial class ColdRoomTemperature
    {
        public long ColdRoomTemperatureID { get; set; }

        public int ColdRoomSensorNumber { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime RecordedWhen { get; set; }

        public decimal Temperature { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ValidFrom { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ValidTo { get; set; }
    }
}
