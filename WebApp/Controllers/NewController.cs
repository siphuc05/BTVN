using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class NewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Sample()
        {
            return View();
        }
    }
}
