using ProxyBanken.DataAccess.Entity;
using System.Collections.Generic;

namespace ProxyBanken.Repository.Interface
{
    public interface IProxyTestRepository : IRepository<ProxyTest>
    {
        ProxyTest GetByProxyTestServer(int proxyId, int testUrlId);
        void BatchUpdate(IList<ProxyTest> ProxyTestServer);
        IList<ProxyTest> GetProxyTests(int proxyId);

    }
}
