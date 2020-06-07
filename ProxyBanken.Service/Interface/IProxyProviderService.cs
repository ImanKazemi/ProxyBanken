using System.Collections.Generic;
using ProxyBanken.DataAccess.Map;

namespace ProxyBanken.Service.Interface
{
    public interface IProxyProviderService
    {
        IEnumerable<ProxyProvider> GetBaseProxies();
        ProxyProvider GetProxyProvider(int id);
        ProxyProvider Update(ProxyProvider proxyProvider);
        int Count();
        int SaveChanges();
    }
}
