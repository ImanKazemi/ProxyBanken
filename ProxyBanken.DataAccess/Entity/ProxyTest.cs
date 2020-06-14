using System;

namespace ProxyBanken.DataAccess.Entity
{
    public class ProxyTest : BaseEntity
    {
        public virtual DateTime? LastSuccessDate { get; set; }
        public int ProxyTestUrlId { get; set; }
        public int ProxyId { get; set; }


    }
}
