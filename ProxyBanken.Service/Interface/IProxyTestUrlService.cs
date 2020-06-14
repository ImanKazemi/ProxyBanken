using ProxyBanken.DataAccess.Entity;
using ProxyBanken.Infrastructure.Model;
using System.Collections.Generic;

namespace ProxyBanken.Service.Interface
{
    public interface IProxyTestUrlService
    {
        List<ProxyTestUrl> GetTestUrls();
        FilteredDataModel<ProxyTestUrl> GetFiltered(int start, int length, string orderCriteria, bool orderAscendingDirection, string searchBy);
        int Count();
        ProxyTestUrl Get(int id);
        int Update(ProxyTestUrl proxyTestUrl);
        int Create(ProxyTestUrl proxyTestUrl);
        int Delete(int id);
        int SaveChanges();

    }
}
