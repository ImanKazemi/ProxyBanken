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

        //public Proxy GetProxyByIpPort(string ip, int port)
        //{
        //    using var context = new ApplicationContext();
        //    var proxy = _context.Set<Proxy>().FirstOrDefault(x => x.Ip == ip && x.Port == port);
        //    return proxy;
        //}

        //public void BatchUpdate(IList<Proxy> proxies)
        //{
        //    if(proxies == null || proxies.Count == 0)
        //    {
        //        return;
        //    }

        //    foreach (var proxy in proxies)
        //    {
        //        try
        //        {
        //            var existedProxy = GetProxyByIpPort(proxy.Ip, proxy.Port);
        //            if (existedProxy != null)
        //            {
        //                existedProxy.ModifiedOn = DateTime.Now;
        //                _context.Entry(existedProxy).State = EntityState.Modified;
        //            }
        //            else
        //            {
        //                proxy.ModifiedOn = proxy.CreatedOn = DateTime.Now;
        //                _context.Add(proxy);
        //            }
        //        }
        //        catch (Exception exception)
        //        {
        //            //log exception
        //        }

        //    }

        //    try
        //    {
        //        _context.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        //log exception

        //    }
        //}

        //public IEnumerable<Proxy> GetPaged(int start, int length)
        //{
        //    return _context.Set<Proxy>().AsQueryable().Skip(start).Take(length).ToList();
        //}

        //public int Count()
        //{
        //    return _context.Set<Proxy>().Count();
        //}
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
