using System.Diagnostics;
using Day08Lab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day08Lab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NetCoreCrudContext _context;
        public HomeController(ILogger<HomeController> logger, NetCoreCrudContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<IActionResult> Product()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .ToListAsync();

            return View(products);
        }

        public IActionResult Index()
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
