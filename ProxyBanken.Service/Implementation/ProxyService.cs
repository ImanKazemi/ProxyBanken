using ProxyBanken.Service.Interface;
using System.Collections.Generic;
using ProxyBanken.DataAccess.Entity;
using ProxyBanken.Repository.Interface;

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

        public IEnumerable<Proxy> GetPagedProxies(int start, int length)
        {
            return _proxyRepository.GetPaged(start, length);

        }

        public void DeleteObsoleteProxy(int days)
        {
            _proxyRepository.DeleteObsoleteProxy(days);
        }
    }
}
