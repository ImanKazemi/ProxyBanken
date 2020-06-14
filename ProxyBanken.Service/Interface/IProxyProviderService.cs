using System.Collections.Generic;
using ProxyBanken.DataAccess.Entity;

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
