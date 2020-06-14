using Microsoft.AspNetCore.Mvc;
using ProxyBanken.Infrastructure.Model;
using ProxyBanken.Service.Interface;
using System.Linq;

namespace ProxyBanken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProxyTestServerApiController : Controller
    {
        private readonly IProxyTestUrlService _proxyTestUrlService;

        public ProxyTestServerApiController(IProxyTestUrlService proxyTestUrlService)
        {
            _proxyTestUrlService = proxyTestUrlService;
        }

        public IActionResult Get([FromBody] DtParameters dtParameters)
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
                orderCriteria = "Name";
                orderAscendingDirection = true;
            }

            var result = _proxyTestUrlService.GetFiltered(dtParameters.Start, dtParameters.Length, orderCriteria, orderAscendingDirection, searchBy);
            return Json(new
            {
                recordsTotal = result.Total,
                recordsFiltered = result.FilteredCount,
                data = result.Result
            });
        }
    }

}

