using Microsoft.AspNetCore.Mvc;

namespace StarterM.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Images = new string[] { "cat_box", "cat_cage" };
            return View();
        }
    }
}
