using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProxyBanken.DataAccess.Entity;

namespace ProxyBanken.DataAccess.Map
{
    public class ProxyTestServerMap
    {
        public ProxyTestServerMap(EntityTypeBuilder<ProxyTestServer> entityBuilder)
        {
            entityBuilder.HasKey(p => p.Id);
        }
    }
}
