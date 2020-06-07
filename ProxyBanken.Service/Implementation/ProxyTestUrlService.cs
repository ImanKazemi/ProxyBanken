using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProxyBanken.DataAccess.Entity;
using ProxyBanken.Repository;
using ProxyBanken.Repository.Interface;
using ProxyBanken.Service.Interface;

namespace ProxyBanken.Service.Implementation
{
    public class ProxyTestUrlService : IProxyTestUrlService
    {
        private static IRepository<ProxyTestUrl> _proxyTestUrlRepository;

        public ProxyTestUrlService(IRepository<ProxyTestUrl> proxyTestUrlRepository)
        {
            _proxyTestUrlRepository = proxyTestUrlRepository;
        }
        public List<ProxyTestUrl> GetTestUrls()
        {
            return _proxyTestUrlRepository.GetAll().ToList();
        }

        public int Count()
        {
            return _proxyTestUrlRepository.Count();
        }
    }
}
