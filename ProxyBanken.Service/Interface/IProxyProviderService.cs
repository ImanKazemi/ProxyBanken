using ProxyBanken.DataAccess.Entity;
using ProxyBanken.Infrastructure.Model;
using System.Collections.Generic;

namespace ProxyBanken.Service.Interface
{
    public interface IProxyProviderService
    {
        IEnumerable<ProxyProvider> GetProxyProviders();
        FilteredDataModel<ProxyProvider> GetFiltered(int start, int length, string orderCriteria, bool orderAscendingDirection, string searchBy);
        ProxyProvider GetProxyProvider(int id);
        int Update(ProxyProvider proxyProvider);
        int Create(ProxyProvider proxyProvider);
        int Delete(int id);
        int Count();
        int SaveChanges();
    }
}
