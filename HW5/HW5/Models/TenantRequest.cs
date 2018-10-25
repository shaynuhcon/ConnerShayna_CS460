using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HW5.Models
{
    public class TenantRequest
    {
        [Key]
        [DisplayName("Request ID")]
        public int RequestId { get; set; }

        [DisplayName("Date Requested")]
        public DateTime Created { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [DisplayName("First Name")]
        [StringLength(50, ErrorMessage = "Name must be less than 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [DisplayName("Last Name")]
        [StringLength(50, ErrorMessage = "Name must be less than 50 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [DisplayName("Phone Number")]
        [RegularExpression("^\\d{3}-\\d{3}-\\d{4}$", ErrorMessage = "Please enter a valid phone number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Apartment name required")]
        [DisplayName("Apartment Name")]
        [StringLength(50, ErrorMessage = "Name must be less than 50 characters")]
        public string ApartmentName { get; set; }

        [Required(ErrorMessage = "Unit number is required")]
        [DisplayName("Unit Number")]
        [Range(0, int.MaxValue, ErrorMessage = "Unit number must be a whole number.")]
        public int UnitNumber { get; set; }

        [Required(ErrorMessage = "Feedback/comments are required.")]
        [DisplayName("Comments")]
        public string Comments { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "Permission required for maintenance.")]
        [DisplayName("Entrance Allowed")]
        public bool IsEntrancePermitted { get; set; }

        // Just for display purposes on the Requests view
        [NotMapped]
        [DisplayName("Name")]
        public string FullName => $"{FirstName} {LastName}";
    }
}