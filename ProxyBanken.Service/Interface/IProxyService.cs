using ProxyBanken.DataAccess;
using System.Collections.Generic;
using ProxyBanken.DataAccess.Entity;

namespace ProxyBanken.Service.Interface
{
    public interface IProxyService
    {
        IEnumerable<Proxy> GetProxies();
        IEnumerable<Proxy> GetPagedProxies(int start, int length);
        int Count();
        Proxy GetProxy(int id);
        void BatchCreateOrUpdate(IList<Proxy> proxies);

        void DeleteObsoleteProxy(int days);

    }
}
