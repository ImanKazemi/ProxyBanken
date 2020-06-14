using ProxyBanken.DataAccess.Entity;
using ProxyBanken.Infrastructure.Model;

namespace ProxyBanken.Repository.Interface
{
    public interface IProxyProviderRepository : IRepository<ProxyProvider>
    {
        FilteredDataModel<ProxyProvider> GetFiltered(int start, int length, string orderCriteria, bool orderAscendingDirection, string searchBy);

    }
}
