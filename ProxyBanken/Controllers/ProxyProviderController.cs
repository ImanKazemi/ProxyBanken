using Microsoft.AspNetCore.Mvc;
using ProxyBanken.DataAccess.Entity;

namespace ProxyBanken.Controllers
{
    public class ProxyProviderController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Insert()
        {
            return View(new ProxyProvider());
        }

        public IActionResult Edit(int id)
        {
            return View("Insert", new ProxyProvider{ Id = id });
        }

        public IActionResult Delete(int id)
        {
            return View(id);
        }
    }
}
