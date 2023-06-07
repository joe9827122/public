using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;

namespace StarterM.Controllers
{
    public class HomeController : Controller
    {
        readonly IMemoryCache _cache;

        public HomeController(IMemoryCache cache)
        {
            _cache = cache;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SetCache()
        {
            //未設定逾期，Cache會與應用程式的生命週期一起存在
            _cache.Set("data1", DateTime.Now);
            return Content("set cache...");
        }

        public IActionResult SetCacheSlide()
        {
            //設定相對逾期
            var options = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(5));
            _cache.Set("data1", DateTime.Now, options);
            return Content("set cache...");
        }

        public IActionResult SetCacheAbsolute()
        {
            //設定絕對逾期
            var options = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(5));
            _cache.Set("data1", DateTime.Now, options);
            return Content("set cache...");
        }

        public IActionResult GetCache()
        {
            //var d = _cache.Get<DateTime>("data1"); // DateTime必有值
            var d = _cache.Get<DateTime?>("data1"); // DateTime? 可以接收null
            return Content($"cache:{d}");
        }

        //設定快取相依性
        public IActionResult SetCache2()
        {
            var source = new CancellationTokenSource();
            var token = new CancellationChangeToken(source.Token);

            _cache.Set("source", source);
            _cache.Set("cache1", DateTime.Now, token);
            _cache.Set("cache2", DateTime.Now, token);
            return Content("Set Cache2...");
        }

        //複合型
        public IActionResult SetCache3()
        {
            var source = new CancellationTokenSource();
            var token = new CancellationChangeToken(source.Token);
            var options = new MemoryCacheEntryOptions()
                .AddExpirationToken(token) //相依性移除設定
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(15)); //設定絕對逾期
            _cache.Set("source", source);
            _cache.Set("cache1", DateTime.Now, token);  // 相依性移除
            _cache.Set("cache2", DateTime.Now, options); // 1.相依性移除  2.15秒後移除
            return Content("Set Cache3...");
        }

        
        public IActionResult RemoveCache()
        {
            var result = _cache.Get<CancellationTokenSource>("source");
            result.Cancel();//移除相依性快取
            return Content("Remove Cache...");
        }

        public IActionResult GetCache2()
        {
            var result = _cache.Get<DateTime?>("cache1");
            var result2 = _cache.Get<DateTime?>("cache2");
            return Content(@$"cache1:{result}
cache2:{result2}");
        }


    }
}
