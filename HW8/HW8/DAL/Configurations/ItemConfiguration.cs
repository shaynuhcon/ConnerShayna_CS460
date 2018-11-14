using System.Data.Entity.ModelConfiguration;
using HW8.Models;

namespace HW8.DAL.Configurations
{
    public class ItemConfiguration : EntityTypeConfiguration<Item>
    {
        public ItemConfiguration()
        {
            ToTable("Item");

            HasKey(x => x.ItemId);

            Property(x => x.ItemId)
                .HasColumnName("ItemID")
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar")
                .IsRequired();

            Property(x => x.Description)
                .HasColumnName("Description")
                .HasColumnType("nvarchar")
                .IsRequired();

            Property(x => x.SellerId)
                .HasColumnName("SellerID")
                .HasColumnType("int")
                .IsRequired();
        }
    }
}