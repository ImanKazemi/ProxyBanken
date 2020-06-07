using System.Collections.Generic;
using ProxyBanken.DataAccess.Entity;

namespace ProxyBanken.Repository.Interface
{
    public interface IProxyTestRepository : IRepository<ProxyTest>
    {
        ProxyTest GetByProxyTestUrl(int proxyId, int testUrlId);
        void BatchUpdate(IList<ProxyTest> proxyTestUrl);
    }
}
