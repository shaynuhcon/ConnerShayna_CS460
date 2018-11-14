using System.Data.Entity.ModelConfiguration;
using HW8.Models;

namespace HW8.DAL.Configurations
{
    public class BuyerConfiguration : EntityTypeConfiguration<Buyer>
    {
        public BuyerConfiguration()
        {
            ToTable("Buyer");

            HasKey(x => x.BuyerId);

            Property(x => x.BuyerId)
                .HasColumnName("BuyerID")
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