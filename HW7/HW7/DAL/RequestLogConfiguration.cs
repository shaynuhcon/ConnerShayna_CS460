using System.Data.Entity.ModelConfiguration;
using HW7.Models;

namespace HW7.DAL
{
    public class RequestLogConfiguration : EntityTypeConfiguration<RequestLog>
    {
        public RequestLogConfiguration()
        {
            ToTable("RequestLog");

            HasKey(x => x.RequestId);
            
            Property(x => x.RequestId)
                .HasColumnName("RequestID")
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.DateInserted)
                .HasColumnName("DateInserted")
                .HasColumnType("datetime")
                .IsRequired();

            Property(x => x.RequestUrl)
                .HasColumnName("RequestUrl")
                .HasColumnType("nvarchar")
                .IsRequired();

            Property(x => x.RequestType)
                .HasColumnName("RequestType")
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Word)
                .HasColumnName("Word")
                .HasColumnType("nvarchar")
                .IsOptional();

            Property(x => x.Ip)
                .HasColumnName("IP")
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Browser)
                .HasColumnName("Browser")
                .HasColumnType("nvarchar")
                .IsRequired();
        }
    }

}