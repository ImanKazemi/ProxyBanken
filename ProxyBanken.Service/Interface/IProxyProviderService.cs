using ProxyBanken.DataAccess.Entity;
using System.Collections.Generic;

namespace ProxyBanken.Service.Interface
{
    public interface IProxyProviderService
    {
        IEnumerable<ProxyProvider> GetBaseProxies();
        ProxyProvider GetProxyProvider(int id);
        int Update(ProxyProvider proxyProvider);
        int Create(ProxyProvider proxyProvider);
        int Delete(int id);
        int Count();
        int SaveChanges();
    }
}
