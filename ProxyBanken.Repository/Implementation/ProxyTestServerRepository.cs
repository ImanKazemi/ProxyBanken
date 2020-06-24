using ProxyBanken.DataAccess.Entity;
using ProxyBanken.Infrastructure.Extention;
using ProxyBanken.Infrastructure.Model;
using ProxyBanken.Repository.Interface;
using System;
using System.Linq;

namespace ProxyBanken.Repository.Implementation
{
    public class ProxyTestServerRepository : Repository<ProxyTestServer>, IProxyTestServerRepository
    {
        private readonly ApplicationContext _context;

        public ProxyTestServerRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public FilteredDataModel<ProxyTestServer> GetFiltered(int start, int length, string orderCriteria, bool orderAscendingDirection, string searchBy)
        {
            var query = _context.Set<ProxyTestServer>().AsQueryable();

            if (!string.IsNullOrEmpty(searchBy))
            {
                searchBy = searchBy.ToUpper();
                query = query.Where(x => (x.Name != null && x.Name.ToUpper().Contains(searchBy)) ||
                (x.Url != null && x.Url.ToUpper().Contains(searchBy)));
            }

            query = orderAscendingDirection ? query.OrderByDynamic(orderCriteria, DtOrderDir.Asc) : query.OrderByDynamic(orderCriteria, DtOrderDir.Desc);

            var result = query.Skip(start).Take(length).ToList();
            return new FilteredDataModel<ProxyTestServer>(result, query.Count(), Count());
        }


    }
}
