using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProxyBanken.DataAccess.Entity;
using ProxyBanken.Repository.Interface;

namespace ProxyBanken.Repository.Implementation
{
    public class ConfigRepository : Repository<Config>, IConfigRepository
    {
        private readonly ApplicationContext _context;

        public ConfigRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public void BatchUpdate(IList<Config> configs)
        {
            if (configs == null || configs.Count == 0)
            {
                return;
            }

            foreach (var config in configs)
            {
                try
                {
                    var oldConfig = GetByName(config.Key);
                    if (oldConfig.Value != config.Value)
                    {
                        oldConfig.Value = config.Value;
                        _context.Entry(oldConfig).State = EntityState.Modified;
                    }
                    else
                    {
                        _context.Entry(oldConfig).State = EntityState.Unchanged;
                    }

                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    //log exception
                    throw;
                }
            }
        }

        public Config GetByName(string name)
        {
            var config = _context.Set<Config>().FirstOrDefault(x => x.Key == name);
            return config;
        }

    }
}
