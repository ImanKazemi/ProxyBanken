using ProxyBanken.DataAccess.Entity;
using ProxyBanken.Infrastructure.Model;
using System.Collections.Generic;

namespace ProxyBanken.Repository.Interface
{
    public interface IProxyRepository : IRepository<Proxy>
    {
        Proxy GetProxyByIpPort(string ip, int port);
        void BatchUpdate(IList<Proxy> proxies);
        FilteredDataModel<Proxy> GetPaged(int start, int length, string orderCriteria, bool orderAscendingDirection, string searchBy);
        void DeleteObsoleteProxy(int days);
    }
}
