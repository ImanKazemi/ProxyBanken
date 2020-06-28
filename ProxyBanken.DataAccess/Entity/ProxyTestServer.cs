using System.ComponentModel.DataAnnotations;

namespace ProxyBanken.DataAccess.Entity
{
    public class ProxyTestServer : BaseEntity
    {
        [Display(Name = "Name")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(1000)]
        [Required]
        [Url]
        public string Url { get; set; }
    }
}
