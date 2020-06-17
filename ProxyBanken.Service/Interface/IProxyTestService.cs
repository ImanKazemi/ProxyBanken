using ProxyBanken.DataAccess.Entity;
using System.Collections.Generic;

namespace ProxyBanken.Service.Interface
{
    public interface IProxyTestService
    {
        void BatchCreateOrUpdate(IList<ProxyTest> proxyTests);
        IList<ProxyTest> GetProxyTests(int proxyId);

    }
}
