using ProxyBanken.Service.Interface;
using System.Collections.Generic;
using ProxyBanken.DataAccess.Map;
using ProxyBanken.Repository.Interface;

namespace ProxyBanken.Service.Implementation
{
    public class ProxyProviderService : IProxyProviderService
    {
        private readonly IRepository<ProxyProvider> _repository;
        public ProxyProviderService(IRepository<ProxyProvider> repository)
        {
            _repository = repository;
        }

        public IEnumerable<ProxyProvider> GetBaseProxies()
        {
            return _repository.GetAll();
        }

        public ProxyProvider GetProxyProvider(int id)
        {
            return _repository.Get(id);
        }

        public int Count()
        {
            return _repository.Count();
        }

        public int SaveChanges()
        {
            return _repository.SaveChanges();
        }

        public ProxyProvider Update(ProxyProvider proxyProvider)
        {
            return _repository.Update(proxyProvider);
        }
    }
}
