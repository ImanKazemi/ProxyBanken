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

            modelBuilder.Entity<Config>().HasData(new { Id = 1, Key = "ProxyUpdateInterval", Value = "10" }, new { Id = 2, Key = "ProxyDeleteInterval", Value = "7" });
            modelBuilder.Entity<ProxyProvider>().HasData(
                new { Id = 1, Url = "https://free-proxy-list.net/", RowQuery = "//table[@id='proxylisttable']/tbody/tr", IpQuery = "//td[1]", PortQuery = "//td[2]" },
                new { Id = 2, Url = "https://www.proxynova.com/proxy-server-list/", RowQuery = "//table/tbody/tr[@data-proxy-id]", IpQuery = "//td[1]/abbr/script", PortQuery = "//td[2]" },
                new { Id = 3, Url = "http://cn-proxy.com/archives/218", RowQuery = "//table/tbody/tr", IpQuery = "//td[1]", PortQuery = "//td[2]" },
                new { Id = 4, Url = "https://www.socks-proxy.net/", RowQuery = "//table/tbody/tr", IpQuery = "//td[1]", PortQuery = "//td[2]" },
                new { Id = 5, Url = "https://free-proxy-list.com", RowQuery = "(//div[contains(@class, 'table-responsive')])[2]/table/tbody/tr", IpQuery = "//td[1]", PortQuery = "//td[3]" }
                );

            modelBuilder.Entity<ProxyTestServer>().HasData(
                 new { Id = 1, Url = "https://google.com", Name = "Google" },
                 new { Id = 2, Url = "https://www.bing.com", Name = "Bing" },
                 new { Id = 3, Url = "https://duckduckgo.com/", Name = "Duck Duck Go" }
            );

        }
    }
}
