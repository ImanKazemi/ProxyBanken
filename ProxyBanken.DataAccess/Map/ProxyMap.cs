using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProxyBanken.DataAccess.Entity;

namespace ProxyBanken.DataAccess.Map
{
    public class ProxyMap
    {
        public ProxyMap(EntityTypeBuilder<Proxy> entityBuilder)
        {
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.HasIndex(p => new { p.Ip, p.Port }).IsUnique();
        }
    }
}
