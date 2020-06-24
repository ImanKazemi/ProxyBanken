using Microsoft.AspNetCore.Mvc;
using ProxyBanken.DataAccess.Entity;
using ProxyBanken.Models;
using ProxyBanken.Service.Interface;
using System.Collections.Generic;
using System.Net;

namespace ProxyBanken.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigApiController : Controller
    {

        private readonly IConfigService _configService;

        public ConfigApiController(IConfigService configService, IProxyTestService proxyTestService)
        {
            _configService = configService;
        }

        [HttpGet]
        public JsonResult ConfigValues()
        {
            ConfigModel config = new ConfigModel
            {
                UpdateInterval = int.Parse(_configService.GetByName("ProxyUpdateInterval").Value),
                DeleteInterval = int.Parse(_configService.GetByName("ProxyDeleteInterval").Value)
            };
            return Json(config);
        }

        [HttpPost]
        public HttpStatusCode Config([FromForm] ConfigModel config)
        {
            try
            {
                IList<Config> configs = new List<Config>();
                configs.Add(new Config
                {
                    Key = "ProxyUpdateInterval",
                    Value = config.UpdateInterval.ToString()
                });

                configs.Add(new Config
                {
                    Key = "ProxyDeleteInterval",
                    Value = config.DeleteInterval.ToString()
                });

                _configService.BatchUpdate(configs);

                return HttpStatusCode.OK;
            }
            catch
            {
                return HttpStatusCode.InternalServerError;
            }

        }
    }
}
