using ProxyBanken.DataAccess.Entity;
using ProxyBanken.Infrastructure.Extention;
using ProxyBanken.Infrastructure.Model;
using ProxyBanken.Repository.Interface;
using System.Linq;

namespace ProxyBanken.Repository.Implementation
{
    public class ProxyProviderRepository : Repository<ProxyProvider>, IProxyProviderRepository
    {
        private readonly ApplicationContext _context;
        public ProxyProviderRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public FilteredDataModel<ProxyProvider> GetFiltered(int start, int length, string orderCriteria, bool orderAscendingDirection, string searchBy)
        {
            var query = _context.Set<ProxyProvider>().AsQueryable();

            if (!string.IsNullOrEmpty(searchBy))
            {
                searchBy = searchBy.ToUpper();
                query = query.Where(x => (x.Url != null && x.Url.ToUpper().Contains(searchBy)) ||
                (x.LastFetchOn != null && x.LastFetchOn.ToString().ToUpper().Contains(searchBy)) ||
                (x.LastFetchProxyCount != null && x.LastFetchProxyCount.ToString().Contains(searchBy)) ||
                (x.RowQuery != null && x.RowQuery.ToUpper().Contains(searchBy)) ||
                (x.IpQuery != null && x.IpQuery.ToUpper().Contains(searchBy)) ||
                (x.PortQuery != null && x.PortQuery.ToUpper().Contains(searchBy)) ||
                (x.Exception != null && x.Exception.ToUpper().Contains(searchBy)));
            }

            query = orderAscendingDirection ? query.OrderByDynamic(orderCriteria, DtOrderDir.Asc) : query.OrderByDynamic(orderCriteria, DtOrderDir.Desc);

            var result = query.Skip(start).Take(length).ToList();
            return new FilteredDataModel<ProxyProvider>(result, query.Count(), Count());
        }


    }
}
