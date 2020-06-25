using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;
using ProxyBanken.DataAccess.Entity;
using ProxyBanken.Helper;
using ProxyBanken.Infrastructure.Model;
using ProxyBanken.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ProxyBanken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProxyApiController : Controller
    {
        private readonly IProxyService _proxyService;
        private readonly IProxyProviderService _proxyProviderService;
        private readonly IProxyTestService _proxyTestService;
        private readonly IProxyTestServerService _proxyTestServerService;
        public ProxyApiController(IProxyService proxyService, IProxyProviderService proxyProviderService = null, IProxyTestService proxyTestService = null, IProxyTestServerService proxyTestServerService = null)
        {
            this._proxyService = proxyService;
            _proxyProviderService = proxyProviderService;
            _proxyTestService = proxyTestService;
            _proxyTestServerService = proxyTestServerService;
        }

        [HttpPost]
        public IActionResult LoadTable([FromBody] DtParameters dtParameters)
        {
            var searchBy = dtParameters.Search?.Value;
            string orderCriteria;
            bool orderAscendingDirection;
            if (dtParameters.Order != null)
            {
                orderCriteria = dtParameters.Columns[dtParameters.Order[0].Column].Data;
                orderAscendingDirection = dtParameters.Order[0].Dir.ToString().ToLower() == "asc";
            }
            else
            {
                orderCriteria = "lastFunctionalityTestDate";
                orderAscendingDirection = true;
            }
            var result = _proxyService.GetPagedProxies(dtParameters.Start, dtParameters.Length, orderCriteria, orderAscendingDirection, searchBy);

            return Json(new
            {
                recordsTotal = result.Total,
                recordsFiltered = result.FilteredCount,
                data = result.Result
            });

        }

        [HttpGet("Update")]
        public HttpStatusCode UpdateProxies()
        {
            var serviceProviders = _proxyProviderService.GetProxyProviders();
            var testServers = _proxyTestServerService.GetTestProxies();

            Parallel.ForEach(serviceProviders, provider =>
            {
                try
                {
                    IList<Proxy> proxyList = ProxyHelper.StartCrawler(provider);
                    provider.LastFetchOn = DateTime.Now;
                    provider.LastFetchProxyCount = proxyList.Count;
                    provider.Exception = "";

                    if (proxyList.Count > 0)
                    {
                        _proxyService.BatchCreateOrUpdate(proxyList);
                        IList<ProxyTest> proxyTestResults = ProxyHelper.TestProxies(proxyList.ToList(), testServers);

                        if (proxyTestResults.Count > 0)
                        {
                            _proxyTestService.BatchCreateOrUpdate(proxyTestResults);
                        }

                    }
                }
                catch (Exception ex)
                {
                    provider.LastFetchProxyCount = -1;
                    provider.Exception = ex.InnerException?.Message;
                }

                _proxyProviderService.Update(provider);

            });

            try
            {
                _proxyProviderService.SaveChanges();
                return HttpStatusCode.OK;
            }
            catch
            {
                return HttpStatusCode.InternalServerError;
            }

        }
    }
}
