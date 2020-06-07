using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProxyBanken.DataAccess.Entity;

namespace ProxyBanken.DataAccess.Map
{
    public class ProxyTestUrlMap
    {
        public ProxyTestUrlMap(EntityTypeBuilder<ProxyTestUrl> entityBuilder)
        {
            entityBuilder.HasKey(p => p.Id);
        }
    }
}
