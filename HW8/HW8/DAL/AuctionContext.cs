using System.Data.Entity;
using HW8.DAL.Configurations;
using HW8.Models;

namespace HW8.DAL
{
    public class AuctionContext : DbContext
    {
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Bid> Bids { get; set; }
        
        public AuctionContext() : base("name=AuctionContext") { }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            // Model configurations to map entity to model
            builder.Configurations.Add(new SellerConfiguration());
            builder.Configurations.Add(new BuyerConfiguration());
            builder.Configurations.Add(new ItemConfiguration());
            builder.Configurations.Add(new BidConfiguration());

        }
    }
}