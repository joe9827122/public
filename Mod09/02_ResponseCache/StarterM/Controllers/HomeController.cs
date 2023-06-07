using Microsoft.AspNetCore.Mvc;

namespace StarterM.Controllers
{
    //以葉面為單位的Cache
    public class HomeController : Controller
    {
        public IActionResult CacheTagDemo()
        {
            return View();
        }

        //[ResponseCache(Duration = 60)]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 60)]
        public IActionResult Index()
        {
            return View();
        }

        //route的方式可以分開Cache
        // /Home/Index2/300
        [ResponseCache(Duration = 60)]
        public IActionResult Index2(string id)
        {
            return View(nameof(Index));
        }

        //QueryKeys 的Cache需要加上VaryByQueryKeys，否則只會有一份Cache
        // /Home/Index3?id2=300
        [ResponseCache(Duration = 60, VaryByQueryKeys = new string[]{"id2"})]
        public IActionResult Index3(string id2)
        {
            return View(nameof(Index));
        }

        // 快取設定檔:default
        [ResponseCache(CacheProfileName = "default")]
        public IActionResult Default()
        {
            return View(nameof(Index));
        }

        // 快取設定檔:never
        [ResponseCache(CacheProfileName = "never")]
        public IActionResult Never()
        {
            return View(nameof(Index));
        }
    }
}
