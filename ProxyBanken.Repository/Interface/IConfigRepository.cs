using ProxyBanken.DataAccess.Entity;
using System.Collections.Generic;

namespace ProxyBanken.Repository.Interface
{
    public interface IConfigRepository : IRepository<Config>
    {
        void BatchUpdate(IList<Config> configs);
        Config GetByName(string name);
    }
}
