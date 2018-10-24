using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace HW5.Models
{
    public class TenantRequest
    {
        [DisplayName("Request ID")]
        public int RequestId { get; set; }

        [DisplayName("Date Requested")]
        public DateTime Created { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Apartment Name")]
        public string ApartmentName { get; set; }

        [DisplayName("Unit Number")]
        public int UnitNumber { get; set; }

        [DisplayName("Comments")]
        public string Comments { get; set; }

        [DisplayName("Entrance Allowed")]
        public bool IsEntrancePermitted { get; set; }

        [NotMapped]
        [DisplayName("Name")]
        public string FullName { get { return $"{FirstName} {LastName}"; } }

    }
}