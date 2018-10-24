using System;

namespace HW5.Models
{
    public class TenantRequest
    {
        public int RequestId { get; set; }

        public DateTime Created { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string ApartmentName { get; set; }

        public int UnitNumber { get; set; }

        public string Comments { get; set; }

        public bool IsEntrancePermitted { get; set; }
    }
}