using ProxyBanken.DataAccess.Entity;
using ProxyBanken.Infrastructure.Model;

namespace ProxyBanken.Repository.Interface
{
    public interface IProxyTestServerRepository : IRepository<ProxyTestServer>
    {
        FilteredDataModel<ProxyTestServer> GetFiltered(int start, int length, string orderCriteria, bool orderAscendingDirection, string searchBy);

    }
}
