using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarterM.Models;

namespace StarterM.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriteCookie()
        {
            //Response.Cookies.Append("username", "aaa");
            Response.Cookies.Append("username", "aaa", new()
            {
                Expires = DateTime.Now.AddDays(1)
            });
            return Content("write cookie...");
        }

        public IActionResult ReadCookie()
        {
            string? value = Request.Cookies["username"];
            return Content($"username: {value}");
        }

        public IActionResult GetCount()
        {
            int i = 1;
            var counter = HttpContext.Session.GetInt32("counter");
            if (counter.HasValue)
            {
                i = counter.Value + 1;
            }
            HttpContext.Session.SetInt32("counter", i);
            return Content($"Count{i}");
        }

        public IActionResult SetSession()
        {
            HttpContext.Session.Set("employee", new Employee
            {
                Id = 1,  Name= "aaa", Age=33
            });

            return Content("Set Session...");
        }

        public IActionResult GetSession()
        {
            Employee? employee = HttpContext.Session.Get<Employee>("employee");
            //return Content($"get session:{employee?.Name}");
            return Content($@"get session
Name: {employee?.Name}
Employee: {HttpContext.Session.GetString("employee")}");
        }

        public IActionResult SetTempSession()
        {
            HttpContext.Session.Set("temp", new Temp
            {
                TempId = 1,
                TempName = "temp"
            });
            return Content("Set Temp Session");
        }
    }
}
