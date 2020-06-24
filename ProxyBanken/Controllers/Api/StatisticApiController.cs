using Microsoft.AspNetCore.Mvc;
using ProxyBanken.Models;
using ProxyBanken.Service.Interface;

namespace ProxyBanken.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticApiController : Controller
    {
        private readonly IProxyService _proxyService;
        private readonly IProxyProviderService _proxyProviderService;
        private readonly IProxyTestServerService _ProxyTestServerService;

        public StatisticApiController(IProxyService proxyService, IProxyProviderService proxyProviderService, IProxyTestServerService ProxyTestServerService)
        {
            _proxyService = proxyService;
            _proxyProviderService = proxyProviderService;
            _ProxyTestServerService = ProxyTestServerService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            HomeModel values = new HomeModel
            {
                ProviderCount = _proxyProviderService.Count(),
                ProxyCount = _proxyService.Count(),
                TestServiceCount = _ProxyTestServerService.Count()
            };
            return Json(values);
        }

    }
}
