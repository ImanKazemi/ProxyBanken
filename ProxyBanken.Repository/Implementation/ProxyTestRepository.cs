using Microsoft.EntityFrameworkCore;
using ProxyBanken.DataAccess.Entity;
using ProxyBanken.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProxyBanken.Repository.Implementation
{
    public class ProxyTestRepository : Repository<ProxyTest>, IProxyTestRepository
    {
        private readonly ApplicationContext _context;

        public ProxyTestRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public ProxyTest GetByProxyTestUrl(int proxyId, int testUrlId)
        {
            var proxyTest = _context.Set<ProxyTest>().Where(x => x.ProxyId == proxyId && x.ProxyTestUrlId == testUrlId).FirstOrDefault();
            return proxyTest;
        }

        public void BatchUpdate(IList<ProxyTest> proxyTests)
        {
            try
            {
                foreach (var proxyTest in proxyTests)
                {
                    var lastTest = GetByProxyTestUrl(proxyTest.ProxyId, proxyTest.ProxyTestUrlId);
                    if (lastTest == null)
                    {
                        _context.Add(proxyTest);

                    }
                    else if (proxyTest.LastSuccessDate.HasValue)
                    {
                        lastTest.LastSuccessDate = proxyTest.LastSuccessDate;
                        _context.Entry(lastTest).State = EntityState.Modified;

                    }
                }

                _context.SaveChanges();
            }
            catch (Exception exception)
            {

            }
        }
    }
}
