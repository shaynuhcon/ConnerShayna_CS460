using System.ComponentModel;

namespace HW6.Models.ViewModels
{
    // Data to be used on client profile page
    public class PersonViewModel
    {
        [DisplayName("Full name")]
        public string FullName { get; set; }

        [DisplayName("Preferred name")]
        public string PreferredName { get; set; }

        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Fax number")]
        public string FaxNumber { get; set; }

        [DisplayName("Email address")]
        public string EmailAddress { get; set; }

        [DisplayName("Member since")]
        public string ValidFrom { get; set; }

        public byte[] Photo { get; set; }
    }
}