using Microsoft.AspNetCore.Mvc;

namespace StarterM.Controllers
{
    //[MyLog] // Controller層級
    public class HomeController : Controller
    {
        //[MyLog] // Action層級
        public IActionResult Index()
        {
            return View();
        }
    }
}
