using System.Collections.Generic;
using ProxyBanken.DataAccess.Entity;

namespace ProxyBanken.Service.Interface
{
    public interface IProxyTestUrlService
    {
        List<ProxyTestUrl> GetTestUrls();
        int Count();
        ProxyTestUrl Get(int id);
        int Update(ProxyTestUrl proxyTestUrl);
        int Create(ProxyTestUrl proxyTestUrl);
        int Delete(int id);
        int SaveChanges();

    }
}
