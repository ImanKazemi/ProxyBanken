using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProxyBanken.DataAccess.Entity;

namespace ProxyBanken.DataAccess.Map
{
    public class ProxyTestMap
    {
        public ProxyTestMap(EntityTypeBuilder<ProxyTest> entityBuilder)
        {
            entityBuilder.HasKey(p => p.Id);          
        }
    }
}
