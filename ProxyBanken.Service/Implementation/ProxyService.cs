using ProxyBanken.DataAccess.Entity;
using ProxyBanken.Infrastructure.Model;
using ProxyBanken.Repository.Interface;
using ProxyBanken.Service.Interface;
using System.Collections.Generic;

namespace ProxyBanken.Service.Implementation
{
    public class ProxyService : IProxyService
    {
        private readonly IProxyRepository _proxyRepository;
        public ProxyService(IProxyRepository proxyRepository)
        {
            _proxyRepository = proxyRepository;
        }

        public Proxy GetProxy(int id)
        {
            return _proxyRepository.Get(id);
        }

        public void BatchCreateOrUpdate(IList<Proxy> proxies)
        {
            _proxyRepository.BatchUpdate(proxies);
        }
        public int Count()
        {
            return _proxyRepository.Count();
        }

        public IEnumerable<Proxy> GetProxies()
        {
            return _proxyRepository.GetAll();

        }

        public FilteredDataModel<Proxy> GetPagedProxies(int start, int length, string orderCriteria, bool orderAscendingDirection, string searchBy)
        {
            return _proxyRepository.GetPaged(start, length, orderCriteria, orderAscendingDirection, searchBy);

        }

        public List<Proxy> GetExpiredProxies(int days)
        {
           return  _proxyRepository.GetExpiredProxies(days);
        }

        public void BatchDelete(List<Proxy> deleteList)
        {
            _proxyRepository.BatchDelete(deleteList);
        }

        public int Update(Proxy proxy)
        {
            _proxyRepository.Update(proxy);
            return _proxyRepository.SaveChanges();
        }

        public List<Proxy> GetProxiesForExport(string orderCriteria, bool orderAscendingDirection, string searchBy)
        {
            return _proxyRepository.GetProxiesForExport(orderCriteria, orderAscendingDirection, searchBy);

        }
    }
}
