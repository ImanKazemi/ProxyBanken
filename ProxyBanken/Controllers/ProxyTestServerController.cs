using Microsoft.AspNetCore.Mvc;
using ProxyBanken.DataAccess.Entity;

namespace ProxyBanken.Controllers
{
    public class ProxyTestServerController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Insert()
        {
            return View(new ProxyTestServer());
        }

        public IActionResult Edit(int id)
        {
            return View("Insert", new ProxyTestServer { Id = id });
        }

        public IActionResult Delete(int id)
        {
            return View(id);
        }

    }
}
