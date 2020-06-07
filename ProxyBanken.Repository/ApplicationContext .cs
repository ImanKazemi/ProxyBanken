using Microsoft.EntityFrameworkCore;
using ProxyBanken.DataAccess.Entity;
using ProxyBanken.DataAccess.Map;

namespace ProxyBanken.Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public ApplicationContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new ProxyMap(modelBuilder.Entity<Proxy>());
            new ProxyProviderMap(modelBuilder.Entity<ProxyProvider>());
            new ProxyTestMap(modelBuilder.Entity<ProxyTest>());
            new ProxyTestUrlMap(modelBuilder.Entity<ProxyTestUrl>());
        }
    }
}
