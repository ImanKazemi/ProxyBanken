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

        public ProxyTest GetByProxyTestServer(int proxyId, int testUrlId)
        {
            var proxyTest = _context.Set<ProxyTest>().Where(x => x.ProxyId == proxyId && x.ProxyTestServerId == testUrlId).FirstOrDefault();
            return proxyTest;
        }

        public void BatchUpdate(IList<ProxyTest> proxyTests)
        {
            try
            {
                foreach (var proxyTest in proxyTests)
                {
                    var lastTest = GetByProxyTestServer(proxyTest.ProxyId, proxyTest.ProxyTestServerId);
                    if (lastTest == null)
                    {
                        _context.Add(proxyTest);

                    }
                    else
                    {
                        lastTest.LastSuccessDate = proxyTest.LastSuccessDate;
                        lastTest.StatusCode = proxyTest.StatusCode;
                        lastTest.ResponseTime = proxyTest.ResponseTime;
                        _context.Entry(lastTest).State = EntityState.Modified;

                    }
                }

               _context.SaveChanges();
            }
            catch (Exception exception)
            {

            }
        }

        public IList<ProxyTest> GetProxyTests(int proxyId)
        {
            var proxyTest = _context.Set<ProxyTest>().Where(x => x.ProxyId == proxyId).Include(x => x.ProxyTestServer).ToList();
            return proxyTest;
        }
    }
}
