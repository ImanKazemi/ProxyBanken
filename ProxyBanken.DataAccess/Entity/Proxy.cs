using System;
using ProxyBanken.DataAccess.Map;

namespace ProxyBanken.DataAccess.Entity
{
    public class Proxy : BaseEntity
    {
        public string Ip { get; set; }
        public int Port { get; set; }
        public DateTime CreatedOn { get; set; }//date when the address was first found in any proxy list
        public DateTime? ModifiedOn { get; set; } //date when the address was last found in any proxy list
        public DateTime? LastFunctionalityTestDate { get; set; } //date of the last successful basic functionality test
        public virtual ProxyProvider BaseUrl { get; set; }
    }
}
