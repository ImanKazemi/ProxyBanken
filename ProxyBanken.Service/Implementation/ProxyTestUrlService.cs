using ProxyBanken.DataAccess.Entity;
using ProxyBanken.Infrastructure.Model;
using ProxyBanken.Repository.Interface;
using ProxyBanken.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace ProxyBanken.Service.Implementation
{
    public class ProxyTestUrlService : IProxyTestUrlService
    {
        private static IProxyTestUrlRepository _proxyTestUrlRepository;

        public ProxyTestUrlService(IProxyTestUrlRepository proxyTestUrlRepository)
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

        public ProxyTestUrl Get(int id)
        {
            return _proxyTestUrlRepository.Get(id);
        }

        public int Update(ProxyTestUrl proxyTestUrl)
        {
            _proxyTestUrlRepository.Update(proxyTestUrl);
            return SaveChanges();
        }

        public int Create(ProxyTestUrl proxyTestUrl)
        {
            return _proxyTestUrlRepository.Insert(proxyTestUrl);
        }

        public int Delete(int id)
        {
            return _proxyTestUrlRepository.Delete(id);
        }

        public int SaveChanges()
        {
            return _proxyTestUrlRepository.SaveChanges();
        }

        public FilteredDataModel<ProxyTestUrl> GetFiltered(int start, int length, string orderCriteria, bool orderAscendingDirection, string searchBy)
        {
            return _proxyTestUrlRepository.GetFiltered(start, length, orderCriteria, orderAscendingDirection, searchBy);
        }
    }
}
