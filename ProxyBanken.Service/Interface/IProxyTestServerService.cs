using ProxyBanken.DataAccess.Entity;
using ProxyBanken.Infrastructure.Model;
using System.Collections.Generic;

namespace ProxyBanken.Service.Interface
{
    public interface IProxyTestServerService
    {
        List<ProxyTestServer> GetTestProxies();
        FilteredDataModel<ProxyTestServer> GetFiltered(int start, int length, string orderCriteria, bool orderAscendingDirection, string searchBy);
        int Count();
        ProxyTestServer Get(int id);
        int Update(ProxyTestServer proxyTestServer);
        int Create(ProxyTestServer proxyTestServer);
        int Delete(int id);
        int SaveChanges();

    }
}
