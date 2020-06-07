using ProxyBanken.DataAccess.Entity;
using ProxyBanken.Repository.Interface;
using ProxyBanken.Service.Interface;
using System.Collections.Generic;

namespace ProxyBanken.Service.Implementation
{
    public class ConfigService : IConfigService
    {
        private readonly IConfigRepository _repository;

        public ConfigService(IConfigRepository repository)
        {
            _repository = repository;
        }

        public void BatchUpdate(IList<Config> configs)
        {
            _repository.BatchUpdate(configs);
        }

        public Config GetByName(string name)
        {
            return _repository.GetByName(name);
        }
    }
}
