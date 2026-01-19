using lib_domain.Entities;
using Microsoft.EntityFrameworkCore;
using lib_application.Ports;

namespace lib_adapters.Adapters
{
    public class Connection : DbContext, IConnection
    {
        public string? StringConexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Audits>? Audits { get; set; }
        public DbSet<Products>? Products { get; set; }
        public DbSet<Types>? Types { get; set; }
    }
}