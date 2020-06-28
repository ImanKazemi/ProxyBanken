using System.ComponentModel.DataAnnotations;

namespace ProxyBanken.DataAccess.Entity
{
    public class Config : BaseEntity
    {
        public string Key { get; set; }

        [MaxLength(50)]
        public string Value { get; set; }
    }
}
