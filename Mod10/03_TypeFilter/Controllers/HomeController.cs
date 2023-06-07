using Microsoft.AspNetCore.Mvc;

namespace StarterM.Controllers
{
    //[TypeFilter(typeof(MyLogAttritube))]
    public class HomeController : Controller
    {
        //[ServiceFilter(typeof(MyLogAttritube))]
        public IActionResult Index()
        {
            return View();
        }
    }
}
