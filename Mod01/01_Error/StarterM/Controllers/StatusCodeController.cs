using Microsoft.AspNetCore.Mvc;

namespace StarterM.Controllers
{
    public class StatusCodeController : Controller
    {
        public IActionResult Index(string code)
        {
            ViewBag.Code = code;
            return View();
        }
    }
}
