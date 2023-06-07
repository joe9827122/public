using Microsoft.AspNetCore.Mvc;
using StarterM.Models;

namespace StarterM.Controllers
{
    public class HomeController : Controller
    {
        //1. 分類: HomeController
        readonly ILogger<HomeController> _logger;

        //pratice4
        readonly ILogger _logger4;

        public HomeController(ILogger<HomeController> logger, ILoggerFactory factory)
        {

            _logger = logger;
            
            //pratice4
            _logger4 = factory.CreateLogger("MyLog");
        }

        public IActionResult Index()
        {
            //2. 輸出訊息: Home.Index...
            //3. 等級:Information
            _logger.LogInformation("Home.Index...");

            //pratice 2 
            _logger.LogCritical("Log Message - Critical");
            _logger.LogError("Log Message - Error");
            _logger.LogWarning("Log Message - Warning");
            _logger.LogInformation("Log Message - Information");
            _logger.LogDebug("Log Message - Debug");
            _logger.LogTrace("Log Message - Trace");

            //pratice3
            _logger.LogCritical("Log Message - Critical:{path}, {time:t}",
                Request.Path, DateTime.Now);
            _logger.LogCritical($"Log Message - Critical:{Request.Path}, {DateTime.Now:t}");
            _logger.LogError("Log Message - Error:{path}", Request.Path);
            _logger.LogWarning("Log Message - Warning:{path}", Request.Path);
            _logger.LogInformation("Log Message - Information:{path}", Request.Path);
            _logger.LogDebug("Log Message - Debug:{path}", Request.Path);
            _logger.LogTrace("Log Message - Trace:{path}", Request.Path);
            //可以查看DateTime的輔助提示
            //Console.WriteLine($"{DateTime.Now:t}");

            //pratice4
            _logger4.LogCritical("Log Message - Critical:{path}, {time:t}",
                Request.Path, DateTime.Now);
            _logger4.LogError("Log Message - Error:{path}", Request.Path);
            _logger4.LogWarning("Log Message - Warning:{path}", Request.Path);
            _logger4.LogInformation("Log Message - Information:{path}", Request.Path);
            _logger4.LogDebug("Log Message - Debug:{path}", Request.Path);
            _logger4.LogTrace("Log Message - Trace:{path}", Request.Path);

            return View();
        }

        //pratice5 
        [HttpPost]
        public IActionResult Index(string number)
        {
            try
            {
                int i = int.Parse(number);
                ViewBag.Message = $"Result: {i * i}";
            }
            catch (ArgumentNullException ex)
            {
                //LogWarning(Event ID, Exception Object, Output String, Output Sting Params)
                _logger.LogWarning(MyLogEvents.ArgumentNullError, ex, "Path:{path}", Request.Path);
                ViewBag.Message = "沒有輸入值";
            }
            catch (OverflowException ex)
            {
                _logger.LogWarning(MyLogEvents.OverflowError, ex, "Path:{path}", Request.Path);
                ViewBag.Message = "超過數值範圍";
            }
            catch (FormatException ex)
            {
                _logger.LogWarning(MyLogEvents.FormatError, ex, "Path:{path}", Request.Path);
                ViewBag.Message = "請輸入數字";
            }
            return View();
        }
    }
}
