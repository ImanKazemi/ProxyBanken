using System.Collections.Generic;
using ProxyBanken.DataAccess.Entity;

namespace ProxyBanken.Repository.Interface
{
    public interface IProxyRepository : IRepository<Proxy>
    {
        Proxy GetProxyByIpPort(string ip, int port);
        void BatchUpdate(IList<Proxy> proxies);
        IEnumerable<Proxy> GetPaged(int start, int length);
        int Count();
    }
}
