using System.Collections.Generic;

namespace HW8.Models.ViewModels
{
    public class ItemDetailViewModel
    {
        public ListItemViewModel Item { get; set; }

        public IEnumerable<ListBidViewModel> PlacedBids { get; set; }
    }
}