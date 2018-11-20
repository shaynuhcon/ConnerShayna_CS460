using System.Data.Entity.ModelConfiguration;
using HW8.Models;

namespace HW8.DAL.Configurations
{
    public class BidConfiguration : EntityTypeConfiguration<Bid>
    {
        public BidConfiguration()
        {
            ToTable("Bid");

            HasKey(x => x.BidId);

            Property(x => x.BidId)
                .HasColumnName("BidID")
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.Price)
                .HasColumnName("Price")
                .HasColumnType("money")
                .IsRequired();

            Property(x => x.Timestamp)
                .HasColumnName("Timestamp")
                .HasColumnType("datetime")
                .IsRequired();

            Property(x => x.ItemId)
                .HasColumnName("ItemID")
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.BuyerId)
                .HasColumnName("BuyerID")
                .HasColumnType("int")
                .IsRequired();
        }
    }
}