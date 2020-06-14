using Microsoft.AspNetCore.Mvc;
using ProxyBanken.DataAccess.Entity;
using ProxyBanken.Service.Interface;

namespace ProxyBanken.Controllers
{
    public class ProxyProviderController : Controller
    {
        private readonly IProxyProviderService _proxyProviderService;

        public ProxyProviderController(IProxyProviderService proxyProviderService)
        {
            _proxyProviderService = proxyProviderService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Insert(int? id)
        {
            var provider = new ProxyProvider();

            if (id.HasValue)
            {
                provider = _proxyProviderService.GetProxyProvider(id.Value);
            }

            return View(provider);
        }

        [HttpPost]
        public IActionResult Insert(ProxyProvider proxy)
        {
            if (proxy.Id > 0)
            {
                _proxyProviderService.Update(proxy);
            }
            else
            {
                _proxyProviderService.Create(proxy);
            }

            return Json(true);
        }

        public IActionResult Delete(int id)
        {
            var provider = _proxyProviderService.GetProxyProvider(id);
            return View(provider);
        }

        [HttpPost]
        public IActionResult Delete(ProxyProvider proxy)
        {
            _proxyProviderService.Delete(proxy.Id);
            return Json(true);
        }

    }
}
