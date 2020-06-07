using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProxyBanken.Service.Interface;
using static ProxyBanken.Models.AuxiliaryModels.DataTableModels;

namespace ProxyBanken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProxyController : Controller
    {
        private readonly IProxyService _proxyService;
        public ProxyController(IProxyService proxyService)
        {
            this._proxyService = proxyService;
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] dtParam dtParameters)
        {
            // var searchBy = dtParameters.Search?.Value;

            //var orderCriteria = string.Empty;
            //var orderAscendingDirection = true;

            //if (dtParameters.Order != null)
            //{
            //    // in this example we just default sort on the 1st column
            //    orderCriteria = dtParameters.Columns[dtParameters.Order[0].Column].Data;
            //    orderAscendingDirection = dtParameters.Order[0].Dir.ToString().ToLower() == "asc";
            //}
            //else
            //{
            //    // if we have an empty search then just order the results by Id ascending
            //    orderCriteria = "Id";
            //    orderAscendingDirection = true;
            //}
            var result = _proxyService.GetPagedProxies(dtParameters.start, dtParameters.length);
            var totalCount = _proxyService.Count();
            return Json(new
            {
                recordsTotal = _proxyService.Count(),
                recordsFiltered = _proxyService.Count(),
                data = result.ToList()
            });

        }

    }

    public class dtParam
    {
        public int draw { get; set; }

        /// <summary>
        /// Paging first record indicator.
        /// This is the start point in the current data set (0 index based - i.e. 0 is the first record).
        /// </summary>
        public int start { get; set; }

        /// <summary>
        /// Number of records that the table can display in the current draw.
        /// It is expected that the number of records returned will be equal to this number, unless the server has fewer records to return.
        /// Note that this can be -1 to indicate that all records should be returned (although that negates any benefits of server-side processing!)
        /// </summary>
        public int length { get; set; }

    }
}
