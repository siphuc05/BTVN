using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class MyController : Controller
    {
        public IActionResult Index1()
        {
            return View();
        }
        public IActionResult MyInfor()
        {
            return View();
        }
    }
}
