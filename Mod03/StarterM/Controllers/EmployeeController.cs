using Microsoft.AspNetCore.Mvc;
using StarterM.Models;

namespace StarterM.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            Employee employee = new Employee
            {
                Id=1, 
                Name="aaa", 
                Age=33
            };
            return View(employee);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            return View();
        }

    }
}
