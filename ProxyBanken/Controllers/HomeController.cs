using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ProxyBanken.DataAccess.Entity;
using ProxyBanken.Helper;
using ProxyBanken.Models;
using ProxyBanken.Service.Interface;

namespace ProxyBanken.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProxyService _proxyService;
        private readonly IProxyProviderService _proxyProviderService;
        private readonly IProxyTestUrlService _proxyTestUrlService;
        private readonly IConfigService _configService;
        public HomeController(ILogger<HomeController> logger, IProxyService proxyService, IProxyProviderService proxyProviderService, IProxyTestUrlService proxyTestUrlService, IConfigService configService)
        {
            _logger = logger;
            _proxyService = proxyService;
            _proxyProviderService = proxyProviderService;
            _proxyTestUrlService = proxyTestUrlService;
            _configService = configService;
        }

        public IActionResult Index()
        {
            ProxyHelper.GetUserIP(HttpContext);
            return View();
        }

        public IActionResult Config()
        {
            ConfigModel config = new ConfigModel
            {
                UpdateInterval = int.Parse(_configService.GetByName("ProxyUpdateInterval").Value),
                DeleteInterval = int.Parse(_configService.GetByName("ProxyDeleteInterval").Value)
            };
            return View(config);
        }

        [HttpPost]
        public IActionResult Config(ConfigModel config)
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

                return Json(true);
            }
            catch
            {
                return Json(false);
            }

        }

        public IActionResult ProxyCount()
        {
            return Json(_proxyService.Count());
        }

        public IActionResult ProviderCount()
        {
            return Json(_proxyProviderService.Count());
        }

        public IActionResult TestServiceCount()
        {
            return Json(_proxyTestUrlService.Count());
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
