﻿using ProxyBanken.DataAccess.Entity;
using ProxyBanken.Repository.Interface;
using ProxyBanken.Service.Interface;
using System.Collections.Generic;

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

        public IList<ProxyTest> GetProxyTests(int proxyId)
        {
            return _proxyTestRepository.GetProxyTests(proxyId);
        }
    }
}
