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
            new ProxyTestServerMap(modelBuilder.Entity<ProxyTestServer>());
            new ConfigMap(modelBuilder.Entity<Config>());

            modelBuilder.Entity<Config>().HasData(new { Id = 1, Key = "ProxyUpdateInterval", Value = "10" }, new { Id = 2, Key = "ProxyDeleteInterval", Value = "7" }) ;
            modelBuilder.Entity<ProxyProvider>().HasData(new { Id = 1, Url= "https://free-proxy-list.net/", RowQuery = "//table[@id='proxylisttable']/tbody/tr", IpQuery = "//td[1]", PortQuery = "//td[2]" }, new { Id = 2, Url= "https://www.proxynova.com/proxy-server-list/", RowQuery = "//table/tbody/tr[@data-proxy-id]", IpQuery = "//td[1]/abbr/script", PortQuery = "//td[2]" });

        }
    }
}
