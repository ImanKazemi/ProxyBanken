using System.ComponentModel.DataAnnotations;

namespace ProxyBanken.DataAccess.Entity
{
    public class ProxyTestServer : BaseEntity
    {
        [Display(Name="Name")]
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
