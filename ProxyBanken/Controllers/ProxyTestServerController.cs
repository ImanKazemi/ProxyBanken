using Microsoft.AspNetCore.Mvc;
using ProxyBanken.DataAccess.Entity;
using ProxyBanken.Service.Interface;

namespace ProxyBanken.Controllers
{
    public class ProxyTestServerController : Controller
    {
        private readonly IProxyTestUrlService _proxyTestUrlService;

        public ProxyTestServerController(IProxyTestUrlService proxyTestUrlService)
        {
            _proxyTestUrlService = proxyTestUrlService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Insert(int? id)
        {
            var proxyTestUrl = new ProxyTestUrl();

            if (id.HasValue)
            {
                proxyTestUrl = _proxyTestUrlService.Get(id.Value);
            }

            return View(proxyTestUrl);
        }

        [HttpPost]
        public IActionResult Insert(ProxyTestUrl proxyTestUrl)
        {
            if (proxyTestUrl.Id > 0)
            {
                _proxyTestUrlService.Update(proxyTestUrl);
            }
            else
            {
                _proxyTestUrlService.Create(proxyTestUrl);
            }

            return Json(true);
        }

        public IActionResult Delete(int id)
        {
            var provider = _proxyTestUrlService.Get(id);
            return View(provider);
        }

        [HttpPost]
        public IActionResult Delete(ProxyTestUrl proxy)
        {
            _proxyTestUrlService.Delete(proxy.Id);
            return Json(true);
        }

    }
}
