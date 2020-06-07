﻿using Microsoft.AspNetCore.Mvc;
using ProxyBanken.Service.Interface;
using System.Linq;

namespace ProxyBanken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProxyTestServerController : Controller
    {
        private readonly IProxyTestUrlService _proxyTestUrlService;

        public ProxyTestServerController(IProxyTestUrlService proxyTestUrlService)
        {
            _proxyTestUrlService = proxyTestUrlService;
        }

        public IActionResult Get()
        {
            var result = _proxyTestUrlService.GetTestUrls();

            return Json(new
            {
                recordsTotal = result.Count,
                recordsFiltered = result.Count,
                data = result.ToList()
            });
        }
    }

}

