using System;

namespace HW8.Models
{
    public class Bid
    {
        public int BidId { get; set; }

        public decimal Price { get; set; }

        public DateTime Timestamp { get; set; }

        public int ItemId { get; set; }

        public int BuyerId { get; set; }
    }
}