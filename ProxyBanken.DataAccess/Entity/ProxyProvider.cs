using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProxyBanken.DataAccess.Entity
{
    public class ProxyProvider : BaseEntity
    {
        [MaxLength(50)]
        [Required]
        public string Url { get; set; }
        public DateTime? LastFetchOn { get; set; }

        [DefaultValue(0)]
        public int? LastFetchProxyCount { get; set; }
        [MaxLength(4000)]
        public string RowQuery { get; set; }
        [MaxLength(4000)]
        public string IpQuery { get; set; }
        [MaxLength(4000)]
        public string PortQuery { get; set; }
        public string Exception { get; set; }
        public virtual IEnumerable<Proxy> Proxies { get; set; }
    }
}
