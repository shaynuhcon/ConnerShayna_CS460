using System.Data.Entity.ModelConfiguration;
using HW5.Models;

namespace HW5.DAL
{
    public class TenantRequestConfiguration : EntityTypeConfiguration<TenantRequest>
    {
        // This class is a configuration that maps between C# and SQL data types 
        public TenantRequestConfiguration()
        {
            ToTable("TenantRequest");
            HasKey(x => x.RequestId);

            Property(x => x.Created)
                .HasColumnName("Created")
                .HasColumnType("datetime");

            Property(x => x.FirstName)
                .HasColumnName("FirstName")
                .HasColumnType("varchar")
                .HasMaxLength(50);

            Property(x => x.LastName)
                .HasColumnName("LastName")
                .HasColumnType("varchar")
                .HasMaxLength(50);
                
            Property(x => x.PhoneNumber)
                .HasColumnName("PhoneNumber")
                .HasColumnType("varchar")
                .HasMaxLength(50);

            Property(x => x.ApartmentName)
                .HasColumnName("ApartmentName")
                .HasColumnType("varchar")
                .HasMaxLength(50);

            Property(x => x.UnitNumber)
                .HasColumnName("UnitNumber")
                .HasColumnType("int");

            Property(x => x.Comments)
                .HasColumnName("Comments")
                .HasColumnType("varchar(max)");

            Property(x => x.IsEntrancePermitted)
                .HasColumnName("IsEntrancePermitted")
                .HasColumnType("bit");
        }
    }
}