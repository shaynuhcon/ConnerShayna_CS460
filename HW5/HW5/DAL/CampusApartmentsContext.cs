using System.Data.Entity;
using HW5.Models;

namespace HW5.DAL
{
    public class CampusApartmentsContext : DbContext
    {
        public DbSet<TenantRequest> TenantRequests { get; set; }

        public CampusApartmentsContext() : base("name=CampusApartmentsContext"){}

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Configurations.Add(new TenantRequestConfiguration());
        }
    }
}