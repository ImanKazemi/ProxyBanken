using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProxyBanken.DataAccess.Map
{
    public class ProxyProviderMap
    {
        public ProxyProviderMap(EntityTypeBuilder<ProxyProvider> entityBuilder)
        {
            entityBuilder.HasKey(p => p.Id);
        }
    }
}
