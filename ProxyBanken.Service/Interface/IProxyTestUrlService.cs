using System.Collections.Generic;
using ProxyBanken.DataAccess.Entity;

namespace ProxyBanken.Service.Interface
{
    public interface IProxyTestUrlService
    {
        List<ProxyTestUrl> GetTestUrls();
        int Count();
    }
}
