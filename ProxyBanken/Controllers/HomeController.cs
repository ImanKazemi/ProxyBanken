using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
        private readonly IConfiguration _configuration;
        public HomeController(ILogger<HomeController> logger, IProxyService proxyService, IProxyProviderService proxyProviderService, IProxyTestUrlService proxyTestUrlService, IConfiguration configuration)
        {
            _logger = logger;
            _proxyService = proxyService;
            _proxyProviderService = proxyProviderService;
            _proxyTestUrlService = proxyTestUrlService;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            ProxyHelper.GetUserIP(HttpContext);
            return View();
        }

        public IActionResult ProxyProvider()
        {
            return View();
        }

        public IActionResult ProxyTestServer()
        {
            return View();
        }

        public IActionResult Config()
        {
            ConfigModel config = new ConfigModel
            {
                UpdateInterval = int.Parse(_configuration["BackgroundService:ProxyUpdateInterval"]),
                DeleteInterval = int.Parse(_configuration["BackgroundService:ProxyDeleteInterval"])
            };
            return View(config);
        }

        [HttpPost]
        public void Config(ConfigModel config)
        {
            _configuration["BackgroundService:ProxyUpdateInterval"] = config.UpdateInterval.ToString();
            _configuration["BackgroundService:ProxyDeleteInterval"] = config.DeleteInterval.ToString();
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
