using System.ComponentModel;

namespace HW6.Models.ViewModels
{
    public class CompanyViewModel
    {
        [DisplayName("Company name")]
        public string CompanyName { get; set; }

        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Fax number")]
        public string FaxNumber { get; set; }

        [DisplayName("Company website")]
        public string Website { get; set; }

        [DisplayName("Member since")]
        public string AccountOpened { get; set; }
    }
}