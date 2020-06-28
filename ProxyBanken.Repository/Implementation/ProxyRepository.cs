using Microsoft.EntityFrameworkCore;
using ProxyBanken.DataAccess.Entity;
using ProxyBanken.Infrastructure.Extention;
using ProxyBanken.Infrastructure.Model;
using ProxyBanken.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProxyBanken.Repository.Implementation
{
    public class ProxyRepository : Repository<Proxy>, IProxyRepository
    {
        private readonly ApplicationContext _context;

        public ProxyRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public Proxy GetProxyByIpPort(string ip, int port)
        {
            var proxy = _context.Set<Proxy>().FirstOrDefault(x => x.Ip == ip && x.Port == port);
            return proxy;
        }

        public void BatchUpdate(IList<Proxy> proxies)
        {
            if (proxies == null || proxies.Count == 0)
            {
                return;
            }

            foreach (var proxy in proxies)
            {
                var existedProxy = GetProxyByIpPort(proxy.Ip, proxy.Port);
                if (existedProxy != null)
                {
                    existedProxy.ModifiedOn = DateTime.Now;
                    existedProxy.LastFunctionalityTestDate = proxy.LastFunctionalityTestDate;
                    existedProxy.Provider = proxy.Provider;
                    existedProxy.Anonymity = proxy.Anonymity;
                    _context.Entry(existedProxy).State = EntityState.Modified;
                    proxy.Id = existedProxy.Id;
                }
                else
                {
                    proxy.ModifiedOn = proxy.CreatedOn = DateTime.Now;

                    _context.Add(proxy);
                    _context.Entry(proxy.Provider).State = EntityState.Detached;
                }
            }

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //throw exception to save in database
                throw;
            }


        }

        public FilteredDataModel<Proxy> GetPaged(int start, int length, string orderCriteria, bool orderAscendingDirection, string searchBy)
        {
            var query = _context.Set<Proxy>().AsQueryable();

            if (!string.IsNullOrEmpty(searchBy))
            {
                searchBy = searchBy.ToUpper();
                query = query.Where(x => (x.CreatedOn != null && x.CreatedOn.ToString().ToUpper().Contains(searchBy)) ||
                (x.Ip != null && x.Ip.ToUpper().Contains(searchBy)) ||
                x.Port.ToString().ToUpper().Contains(searchBy) ||
                (x.ModifiedOn != null && x.ModifiedOn.ToString().ToUpper().Contains(searchBy)) ||
                (x.LastFunctionalityTestDate != null && x.LastFunctionalityTestDate.ToString().ToUpper().Contains(searchBy)));
            }


            query = orderAscendingDirection ? query.OrderByDynamic(orderCriteria, DtOrderDir.Asc) : query.OrderByDynamic(orderCriteria, DtOrderDir.Desc);

            var result = query.Skip(start).Take(length).ToList();
            return new FilteredDataModel<Proxy>(result, query.Count(), Count());
        }


        public List<Proxy> GetExpiredProxies(int days)
        {
            var dateOfDeletation = DateTime.Now.AddDays(days * -1);
            var proxies = _context.Set<Proxy>().Where(x => (x.LastFunctionalityTestDate <= dateOfDeletation || x.LastFunctionalityTestDate == null) && x.ModifiedOn <= dateOfDeletation).ToList();

            return proxies;

        }

        public void BatchDelete(List<Proxy> deleteList)
        {
            foreach (var proxy in deleteList)
            {
                _context.Remove(proxy);
            }
            _context.SaveChanges();
        }

        public List<Proxy> GetProxiesForExport(string orderCriteria, bool orderAscendingDirection, string searchBy)
        {
            var query = _context.Set<Proxy>().AsQueryable();

            if (!string.IsNullOrEmpty(searchBy))
            {
                searchBy = searchBy.ToUpper();
                query = query.Where(x => (x.CreatedOn != null && x.CreatedOn.ToString().ToUpper().Contains(searchBy)) ||
                (x.Ip != null && x.Ip.ToUpper().Contains(searchBy)) ||
                x.Port.ToString().ToUpper().Contains(searchBy) ||
                (x.ModifiedOn != null && x.ModifiedOn.ToString().ToUpper().Contains(searchBy)) ||
                (x.LastFunctionalityTestDate != null && x.LastFunctionalityTestDate.ToString().ToUpper().Contains(searchBy)));
            }
            query = orderAscendingDirection ? query.OrderByDynamic(orderCriteria, DtOrderDir.Asc) : query.OrderByDynamic(orderCriteria, DtOrderDir.Desc);
            var result = query.ToList();
            return result;
        }
    }
}
