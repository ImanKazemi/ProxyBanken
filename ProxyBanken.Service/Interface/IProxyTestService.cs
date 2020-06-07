using System.Collections.Generic;
using ProxyBanken.DataAccess.Entity;

namespace ProxyBanken.Service.Interface
{
    public interface IProxyTestService
    {
        void BatchCreateOrUpdate(IList<ProxyTest> proxyTests);
    }
}
