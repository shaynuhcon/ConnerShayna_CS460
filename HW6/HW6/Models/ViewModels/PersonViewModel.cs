using System;

namespace HW6.Models.ViewModels
{
    public class PersonViewModel
    {
        public string FullName { get; set; }

        public string PreferredName { get; set; }

        public string PhoneNumber { get; set; }

        public string FaxNumber { get; set; }

        public string EmailAddress { get; set; }

        public DateTime ValidFrom { get; set; }

        public byte[] Photo { get; set; }
    }
}