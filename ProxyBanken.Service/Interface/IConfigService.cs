using ProxyBanken.DataAccess.Entity;
using System.Collections.Generic;

namespace ProxyBanken.Service.Interface
{
    public interface IConfigService
    {
        void BatchUpdate(IList<Config> configs);
        Config GetByName(string name);
    }
}
