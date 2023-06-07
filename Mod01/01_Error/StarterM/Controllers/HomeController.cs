using Microsoft.AspNetCore.Mvc;

namespace StarterM.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string number)
        {
            int i = int.Parse(number);
            ViewBag.result = $"Result: {i * i}";
            return View();
        }
    }
}
