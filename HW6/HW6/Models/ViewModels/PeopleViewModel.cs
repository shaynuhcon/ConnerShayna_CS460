using System.Collections.Generic;

namespace HW6.Models.ViewModels
{
    public class PeopleViewModel
    {
        // User search input
        public string Name { get; set; }

        // List to store search results
        public IEnumerable<PersonSearchViewModel> PeopleResults { get; set; }
    }
}