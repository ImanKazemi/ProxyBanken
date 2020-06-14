using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ProxyBanken.DataAccess.Entity
{
    public class ProxyProvider : BaseEntity
    {
        public string Url { get; set; }
        public DateTime? LastFetchOn { get; set; }

        [DefaultValue(0)]
        public int? LastFetchProxyCount { get; set; }
        public string RowQuery { get; set; }
        public string IpQuery { get; set; }
        public string PortQuery { get; set; }
        public string Exception { get; set; }
        public virtual IEnumerable<Proxy> Proxies { get; set; }
    }
}
