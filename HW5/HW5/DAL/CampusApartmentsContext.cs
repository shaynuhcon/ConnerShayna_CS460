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
            // Model configuration to map entity to model
            builder.Configurations.Add(new TenantRequestConfiguration());
        }
    }
}