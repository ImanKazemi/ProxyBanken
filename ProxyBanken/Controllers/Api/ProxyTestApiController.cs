using Microsoft.AspNetCore.Mvc;
using ProxyBanken.Helper;
using ProxyBanken.Infrastructure.Enum;
using ProxyBanken.Service.Interface;
using System;
using System.Linq;
using System.Net;

namespace ProxyBanken.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProxyTestApiController : Controller
    {
        private readonly IProxyTestService _proxyTestService;
        private readonly IProxyService _proxyService;
        private readonly IProxyTestServerService _proxyTestServerService;

        public ProxyTestApiController(IProxyTestService proxyTestService, IProxyService proxyService, IProxyTestServerService proxyTestServerService = null)
        {
            _proxyTestService = proxyTestService;
            _proxyService = proxyService;
            _proxyTestServerService = proxyTestServerService;
        }

        public IActionResult Get(int proxyId)
        {
            return Json(_proxyTestService.GetProxyTests(proxyId));
        }

        [HttpGet("ProxyTest")]
        public HttpStatusCode TestProxy(int id)
        {
            try
            {
                var proxy = _proxyService.GetProxy(id);
                var testServers = _proxyTestServerService.GetTestProxies().ToList();

                var pingDate = ProxyHelper.Ping(proxy.Ip);

                if (pingDate.HasValue)
                {
                    proxy.LastFunctionalityTestDate = pingDate.Value;
                }

                var anonymity = ProxyHelper.CheckAnonymity(proxy.Ip, proxy.Port);

                if (anonymity != ProxyAnonymity.Unknown)
                {
                    proxy.Anonymity = anonymity;
                }

                var proxyTests = ProxyHelper.TestProxy(proxy, testServers);

                _proxyTestService.BatchCreateOrUpdate(proxyTests);
               
                _proxyService.Update(proxy);

                return HttpStatusCode.OK;
            }
            catch
            {
                return HttpStatusCode.InternalServerError;
            }

        }
    }
}
