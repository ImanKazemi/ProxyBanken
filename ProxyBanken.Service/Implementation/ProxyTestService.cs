using ProxyBanken.Service.Interface;
using System.Collections.Generic;
using ProxyBanken.DataAccess.Entity;
using ProxyBanken.Repository.Interface;

namespace ProxyBanken.Service.Implementation
{
    public class ProxyTestService : IProxyTestService
    {
        private readonly IProxyTestRepository _proxyTestRepository;
        public ProxyTestService(IProxyTestRepository proxyTestRepository)
        {
            _proxyTestRepository = proxyTestRepository;
        }


        public void BatchCreateOrUpdate(IList<ProxyTest> proxyTests)
        {
            _proxyTestRepository.BatchUpdate(proxyTests);
        }

        public IEnumerable<ProxyTest> GetProxies()
        {
            return _proxyTestRepository.GetAll();

        }

    }
}
