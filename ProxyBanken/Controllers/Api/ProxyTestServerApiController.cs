using Microsoft.AspNetCore.Mvc;
using ProxyBanken.DataAccess.Entity;
using ProxyBanken.Infrastructure.Model;
using ProxyBanken.Service.Interface;
using System.Linq;
using System.Net;

namespace ProxyBanken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProxyTestServerApiController : Controller
    {
        private readonly IProxyTestServerService _ProxyTestServerService;

        public ProxyTestServerApiController(IProxyTestServerService ProxyTestServerService)
        {
            _ProxyTestServerService = ProxyTestServerService;
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

            var result = _ProxyTestServerService.GetFiltered(dtParameters.Start, dtParameters.Length, orderCriteria, orderAscendingDirection, searchBy);
            return Json(new
            {
                recordsTotal = result.Total,
                recordsFiltered = result.FilteredCount,
                data = result.Result
            });
        }

        [HttpPost("Insert")]
        public HttpStatusCode Insert([FromForm] ProxyTestServer proxyTestServer)
        {
            try
            {
                if (proxyTestServer.Id > 0)
                {
                    _ProxyTestServerService.Update(proxyTestServer);
                }
                else
                {
                    _ProxyTestServerService.Create(proxyTestServer);
                }
                return HttpStatusCode.OK;

            }
            catch
            {
                return HttpStatusCode.InternalServerError;
            }
        }

        [Route("{id:int}")]
        public ActionResult Get(int id)
        {
            var provider = _ProxyTestServerService.Get(id);
            return Json(provider);
        }

        [HttpDelete("Delete")]
        public HttpStatusCode Delete([FromForm] int id)
        {
            try
            {
                _ProxyTestServerService.Delete(id);
                return HttpStatusCode.OK;
            }
            catch
            {
                return HttpStatusCode.InternalServerError;
            }
        }

    }

}

