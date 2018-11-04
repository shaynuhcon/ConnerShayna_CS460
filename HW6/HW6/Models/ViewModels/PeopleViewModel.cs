﻿using System.Collections.Generic;

namespace HW6.Models.ViewModels
{
    public class PeopleViewModel
    {
        public string Name { get; set; }

        public IEnumerable<PersonSearchViewModel> PeopleResults { get; set; }
    }
}