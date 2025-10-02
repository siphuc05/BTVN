using Category_Product.Models;
using Microsoft.AspNetCore.Mvc;

namespace Category_Product.Controllers
{
    public class ProductController : Controller
    {
        private static List<Category> categories = new List<Category>()
        {
            new Category{Id=1, Name="Điện thoại"},
            new Category{Id=2, Name="Laptop"},
            new Category{Id=3, Name="Phụ kiện" }
        };
        private static List<Product> products = new List<Product>()
        {
            new Product
            {
                Id = 1,
                Name = "iPhone 15 Pro Max",
                Price = 30000000,
                SalePrice = 25000000,
                Description = "Điện thoại cao cấp của Apple.",
                CategoryId = 1,
                Category = new Category{ Id = 1, Name = "Điện thoại" },
                Image = "/Images/iphone15promax.jpg"
            },
            new Product
            {
                Id = 2,
                Name = "MacBook Air M2",
                Price = 28000000,
                SalePrice = 24000000,
                Description = "Laptop Apple MacBook Air chip M2.",
                CategoryId = 2,
                Category = new Category{ Id = 2, Name = "Laptop" },
                Image = "/Images/macbookairm2.jpg"
            },
            new Product
            {
                Id = 3,
                Name = "Tai nghe AirPods Pro 2",
                Price = 6500000,
                SalePrice = 5500000,
                Description = "Tai nghe chống ồn cao cấp của Apple.",
                CategoryId = 3,
                Category = new Category{ Id = 3, Name = "Phụ kiện" },
                Image = "/Images/airpodspro2.jpg"
            }
        };
        public IActionResult Index()
        {
            return View(products);
        }
        public IActionResult Create()
        {
            ViewBag.Categories = categories;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (product.FileUpload != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/products", product.FileUpload.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    product.FileUpload.CopyTo(stream);
                }
                product.Image = "/products/" + product.FileUpload.FileName;
            }
            else
            {
                ModelState.AddModelError("FileUpload", "Bạn phải chọn ảnh");
            }

            if (ModelState.IsValid)
            {
                product.Id = products.Count + 1;
                product.Category = categories.FirstOrDefault(c => c.Id == product.CategoryId);
                products.Add(product);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = categories;
            return View(product);
        }


        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }

        public IActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            ViewBag.Categories = categories;
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            var existing = products.FirstOrDefault(p => p.Id == product.Id);
            if (existing == null) return NotFound();

  

            if (ModelState.IsValid)
            {
                existing.Name = product.Name;
                existing.Price = product.Price;
                existing.SalePrice = product.SalePrice;
                existing.Description = product.Description;
                existing.CategoryId = product.CategoryId;
                existing.Category = categories.FirstOrDefault(c => c.Id == product.CategoryId);

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = categories;
            return View(product);
        }


        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            products.Remove(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
