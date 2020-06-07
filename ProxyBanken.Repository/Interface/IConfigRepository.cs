using System.Collections.Generic;
using ProxyBanken.DataAccess.Entity;

namespace ProxyBanken.Repository.Interface
{
    public interface IConfigRepository : IRepository<Config>
    {
        void BatchUpdate(IList<Config> configs);
        Config GetByName(string name);
    }
}
