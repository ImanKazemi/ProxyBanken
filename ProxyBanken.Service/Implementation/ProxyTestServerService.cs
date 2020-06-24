using ProxyBanken.DataAccess.Entity;
using ProxyBanken.Infrastructure.Model;
using ProxyBanken.Repository.Interface;
using ProxyBanken.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace ProxyBanken.Service.Implementation
{
    public class ProxyTestServerService : IProxyTestServerService
    {
        private static IProxyTestServerRepository _ProxyTestServerRepository;

        public ProxyTestServerService(IProxyTestServerRepository ProxyTestServerRepository)
        {
            _ProxyTestServerRepository = ProxyTestServerRepository;
        }
        public List<ProxyTestServer> GetTestProxies()
        {
            return _ProxyTestServerRepository.GetAll().ToList();
        }

        public int Count()
        {
            return _ProxyTestServerRepository.Count();
        }

        public ProxyTestServer Get(int id)
        {
            return _ProxyTestServerRepository.Get(id);
        }

        public int Update(ProxyTestServer ProxyTestServer)
        {
            _ProxyTestServerRepository.Update(ProxyTestServer);
            return SaveChanges();
        }

        public int Create(ProxyTestServer ProxyTestServer)
        {
            return _ProxyTestServerRepository.Insert(ProxyTestServer);
        }

        public int Delete(int id)
        {
            return _ProxyTestServerRepository.Delete(id);
        }

        public int SaveChanges()
        {
            return _ProxyTestServerRepository.SaveChanges();
        }

        public FilteredDataModel<ProxyTestServer> GetFiltered(int start, int length, string orderCriteria, bool orderAscendingDirection, string searchBy)
        {
            return _ProxyTestServerRepository.GetFiltered(start, length, orderCriteria, orderAscendingDirection, searchBy);
        }
    }
}
