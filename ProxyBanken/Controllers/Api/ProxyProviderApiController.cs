using Microsoft.AspNetCore.Mvc;
using ProxyBanken.DataAccess.Entity;
using ProxyBanken.Infrastructure.Model;
using ProxyBanken.Service.Interface;
using System.Net;

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

        public IActionResult Data([FromBody] DtParameters dtParameters)
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
                orderCriteria = "LastFetchOn";
                orderAscendingDirection = true;
            }
            var result = _proxyProviderService.GetFiltered(dtParameters.Start, dtParameters.Length, orderCriteria, orderAscendingDirection, searchBy);

            return Json(new
            {
                recordsTotal = result.Total,
                recordsFiltered = result.FilteredCount,
                data = result.Result
            });
        }

        [Route("{id:int}")]
        public ActionResult Get(int id)
        {
            var provider = _proxyProviderService.GetProxyProvider(id);
            return Json(provider);
        }

        [HttpPost("Insert")]
        public HttpStatusCode Insert([FromForm] ProxyProvider proxy)
        {
            try
            {
                if (proxy.Id > 0)
                {
                    _proxyProviderService.Update(proxy);
                }
                else
                {
                    _proxyProviderService.Create(proxy);
                }
                return HttpStatusCode.OK;

            }
            catch
            {
                return HttpStatusCode.InternalServerError;
            }
        }

        [HttpDelete("Delete")]
        public HttpStatusCode Delete([FromForm] int id)
        {
            try
            {
                _proxyProviderService.Delete(id);
                return HttpStatusCode.OK;
            }
            catch
            {
                return HttpStatusCode.InternalServerError;
            }
        }
    }
}