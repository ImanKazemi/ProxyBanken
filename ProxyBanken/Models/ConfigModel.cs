using System.ComponentModel.DataAnnotations;

namespace ProxyBanken.Models
{
    public class ConfigModel
    {
        [Display(Name = "Proxy Update Interval (in Minutes)")]
        public int UpdateInterval { get; set; }

        [Display(Name = "Obsolete Proxy Delete Interval (in Days)")]
        public int DeleteInterval { get; set; }
    }
}
