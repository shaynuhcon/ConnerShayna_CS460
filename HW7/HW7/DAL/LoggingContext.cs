using System.Data.Entity;
using HW7.Models;

namespace HW7.DAL
{
    public class LoggingContext : DbContext
    {
        public DbSet<RequestLog> RequestLogs { get; set; }

        public LoggingContext() : base("name=LoggingContext") { }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            // Model configuration to map entity to model
            builder.Configurations.Add(new RequestLogConfiguration());
        }
    }
}