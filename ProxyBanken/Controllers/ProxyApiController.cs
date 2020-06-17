using Microsoft.AspNetCore.Mvc;
using ProxyBanken.Infrastructure.Model;
using ProxyBanken.Service.Interface;
using System.Threading.Tasks;

namespace ProxyBanken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProxyApiController : Controller
    {
        private readonly IProxyService _proxyService;
        public ProxyApiController(IProxyService proxyService)
        {
            this._proxyService = proxyService;
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





    }
}
