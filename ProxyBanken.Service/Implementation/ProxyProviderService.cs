using ProxyBanken.DataAccess.Entity;
using ProxyBanken.Infrastructure.Model;
using ProxyBanken.Repository.Interface;
using ProxyBanken.Service.Interface;
using System.Collections.Generic;

namespace ProxyBanken.Service.Implementation
{
    public class ProxyProviderService : IProxyProviderService
    {
        private readonly IProxyProviderRepository _repository;
        public ProxyProviderService(IProxyProviderRepository repository)
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

        public int Update(ProxyProvider proxyProvider)
        {
            _repository.Update(proxyProvider);
            return SaveChanges();
        }

        public int Create(ProxyProvider proxyProvider)
        {
            return _repository.Insert(proxyProvider);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }

        public FilteredDataModel<ProxyProvider> GetFiltered(int start, int length, string orderCriteria, bool orderAscendingDirection, string searchBy)
        {
            return _repository.GetFiltered(start, length, orderCriteria, orderAscendingDirection, searchBy);
        }
    }
}
