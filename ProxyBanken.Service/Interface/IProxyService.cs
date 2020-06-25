using ProxyBanken.DataAccess.Entity;
using ProxyBanken.Infrastructure.Model;
using System.Collections.Generic;

namespace ProxyBanken.Service.Interface
{
    public interface IProxyService
    {
        IEnumerable<Proxy> GetProxies();
        FilteredDataModel<Proxy> GetPagedProxies(int start, int length, string orderCriteria, bool orderAscendingDirection, string searchBy);
        int Count();
        Proxy GetProxy(int id);
        void BatchCreateOrUpdate(IList<Proxy> proxies);
        List<Proxy> GetExpiredProxies(int days);
        void BatchDelete(List<Proxy> deleteList);
        int Update(Proxy proxy);
    }
}
