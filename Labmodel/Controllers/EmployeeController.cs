using Labmodel.Models;
using Microsoft.AspNetCore.Mvc;

namespace Labmodel.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            var employees = new List<Employee>
            {
                new Employee { Id = 1, FullName = "Nguyễn Văn A", Gender = "Nam", Phone = "0123456789", Email = "a@email.com", Salary = 1000, Status = "Active" },
                new Employee { Id = 2, FullName = "Trần Thị B", Gender = "Nữ", Phone = "0987654321", Email = "b@email.com", Salary = 1500, Status = "Inactive" },
                new Employee { Id = 3, FullName = "Lê Văn C", Gender = "Nam", Phone = "0911222333", Email = "c@email.com", Salary = 2000, Status = "Active" }
            };

            return View(employees);
        }
    }
}
