using ProxyBanken.Infrastructure.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProxyBanken.DataAccess.Entity
{
    public class Proxy : BaseEntity
    {
        [MaxLength(15)]
        public string Ip { get; set; }
        public int Port { get; set; }
        public ProxyAnonymity Anonymity { get; set; }
        public DateTime CreatedOn { get; set; }//date when the address was first found in any proxy list
        public DateTime? ModifiedOn { get; set; } //date when the address was last found in any proxy list
        public DateTime? LastFunctionalityTestDate { get; set; } //date of the last successful basic functionality test
        public virtual ProxyProvider Provider { get; set; } //last provider that found this proxy 
    }
}
