using ProxyBanken.DataAccess.Entity;
using ProxyBanken.Infrastructure.Model;

namespace ProxyBanken.Repository.Interface
{
    public interface IProxyTestUrlRepository : IRepository<ProxyTestUrl>
    {
        FilteredDataModel<ProxyTestUrl> GetFiltered(int start, int length, string orderCriteria, bool orderAscendingDirection, string searchBy);

    }
}
