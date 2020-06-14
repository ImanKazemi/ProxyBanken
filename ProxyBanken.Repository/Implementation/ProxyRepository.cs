using Microsoft.EntityFrameworkCore;
using ProxyBanken.DataAccess.Entity;
using ProxyBanken.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProxyBanken.Repository.Implementation
{
    public class ProxyRepository : Repository<Proxy>, IProxyRepository
    {
        private readonly ApplicationContext _context;

        public ProxyRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public Proxy GetProxyByIpPort(string ip, int port)
        {
            var proxy = _context.Set<Proxy>().FirstOrDefault(x => x.Ip == ip && x.Port == port);
            return proxy;
        }

        public void BatchUpdate(IList<Proxy> proxies)
        {
            if (proxies == null || proxies.Count == 0)
            {
                return;
            }

            foreach (var proxy in proxies)
            {
                try
                {
                    var existedProxy = GetProxyByIpPort(proxy.Ip, proxy.Port);
                    if (existedProxy != null)
                    {
                        existedProxy.ModifiedOn = DateTime.Now;
                        _context.Entry(existedProxy).State = EntityState.Modified;
                    }
                    else
                    {
                        proxy.ModifiedOn = proxy.CreatedOn = DateTime.Now;
                        _context.Add(proxy);
                    }
                }
                catch (Exception exception)
                {
                    //log exception
                }

            }

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //log exception
                throw;
            }
        }

        public IEnumerable<Proxy> GetPaged(int start, int length)
        {
            return _context.Set<Proxy>().AsQueryable().Skip(start).Take(length).ToList();
        }


        public void DeleteObsoleteProxy(int days)
        {
            var dateOfDeletation = DateTime.Now.AddDays(days * -1);
            var proxies = _context.Set<Proxy>().Where(x => x.LastFunctionalityTestDate <= dateOfDeletation || (x.LastFunctionalityTestDate == null && x.ModifiedOn <= dateOfDeletation)).ToList();

            foreach (var proxy in proxies)
            {
                _context.Remove(proxy);
            }

            _context.SaveChanges();
        }
    }
}
