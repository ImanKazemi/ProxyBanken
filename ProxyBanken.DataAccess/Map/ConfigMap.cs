using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProxyBanken.DataAccess.Entity;

namespace ProxyBanken.DataAccess.Map
{
    public class ConfigMap
    {
        public ConfigMap(EntityTypeBuilder<Config> entityBuilder)
        {
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.HasIndex(p => new { p.Key }).IsUnique();
        }
    }
}
