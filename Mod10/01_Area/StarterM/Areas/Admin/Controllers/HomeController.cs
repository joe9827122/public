using Microsoft.AspNetCore.Mvc;

namespace StarterM.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")] //必須要加，否則會找到兩個HomeController而報錯
        public IActionResult Index()
        {
            return View();
        }
    }
}
