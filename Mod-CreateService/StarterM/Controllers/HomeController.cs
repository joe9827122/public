using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace StarterM.Controllers
{
    public class HomeController : Controller
    {
        readonly IMyService _service;

        readonly IFileProvider _provider;

        public HomeController(IMyService service, IFileProvider provider)
        {
            _service = service;
            _provider = provider;
        }

        public IActionResult Index()
        {
            //IMyService service = new MyService();
            //Console.WriteLine(service.Id);
            //Console.WriteLine(service.Id);

            ViewBag.id = _service.Id;

            var contents = _provider.GetDirectoryContents("");
            return View(contents);
        }

        //View 可以使用ViewBag傳遞資訊，但是Index需要有contents的資料
        public IActionResult Select(string name)
        {
            var contents = _provider.GetDirectoryContents("");
            var file = _provider.GetFileInfo(name);
            using var reader = new StreamReader(file.CreateReadStream());
            ViewBag.result = reader.ReadToEnd();
            return View(nameof(Index), contents);
        }

        //RedirectToAction 需要使用TempData才能夠傳遞資訊
        public IActionResult Select2(string name)
        {
            var file = _provider.GetFileInfo(name);
            using var reader = new StreamReader(file.CreateReadStream());
            TempData["result"] = reader.ReadToEnd();
            return RedirectToAction(nameof(Index));
        }
    }
}
