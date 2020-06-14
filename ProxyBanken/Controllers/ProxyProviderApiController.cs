using Microsoft.AspNetCore.Mvc;
using ProxyBanken.Service.Interface;
using System.Linq;

namespace ProxyBanken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProxyProviderApiController : Controller
    {
        private readonly IProxyProviderService _proxyProviderService;

        public ProxyProviderApiController(IProxyProviderService proxyProviderService)
        {
            _proxyProviderService = proxyProviderService;
        }

        public IActionResult Get()
        {
            var result = _proxyProviderService.GetBaseProxies();

            return Json(new
            {
                recordsTotal = result.Count(),
                recordsFiltered = result.Count(),
                data = result.ToList()
            });
        }
    }

}

