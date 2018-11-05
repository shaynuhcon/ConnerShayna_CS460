namespace HW6.Models.ViewModels
{
    public class PersonSearchViewModel
    {
        // ID of person in database, not displayed to user
        public int PersonID { get; set; }

        // Full name to display to user in view
        public string FullName { get; set; }
    }
}