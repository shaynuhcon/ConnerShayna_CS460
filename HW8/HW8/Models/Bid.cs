namespace HW8.Models
{
    public class Bid
    {
        public int BidId { get; set; }

        public string Price { get; set; }

        public string Timestamp { get; set; }

        public int ItemId { get; set; }

        public int BuyerId { get; set; }
    }
}