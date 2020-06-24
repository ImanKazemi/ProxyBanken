using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProxyBanken.DataAccess.Entity;
using ProxyBanken.Helper;
using ProxyBanken.Models;
using ProxyBanken.Service.Interface;
using System.Collections.Generic;
using System.Diagnostics;

namespace ProxyBanken.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Config()
        {
            return View();
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
