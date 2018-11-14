using System.Data.Entity.ModelConfiguration;
using HW8.Models;

namespace HW8.DAL.Configurations
{
    public class SellerConfiguration : EntityTypeConfiguration<Seller>
    {
        public SellerConfiguration()
        {
            ToTable("Seller");

            HasKey(x => x.SellerId);

            Property(x => x.SellerId)
                .HasColumnName("SellerID")
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}