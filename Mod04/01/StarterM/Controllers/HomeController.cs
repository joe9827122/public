using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StarterM.Models;

namespace StarterM.Controllers
{
    public class HomeController : Controller
    {

        //程式啟動時注入，Config變更不會重抓，須重啟程式
        //readonly IOptions<WebSiteProfile> _options;
        //public HomeController(IOptions<WebSiteProfile> options)
        //{
        //    _options = options;
        //}

        //Snapsshot重新整理時會蟲抓Config
        readonly IOptionsSnapshot<WebSiteProfile> _options;

        public IActionResult Index()
        {
            //return View(_options.Value);
            WebSiteProfile wsp = new WebSiteProfile();
            _config.GetSection("one:two").Bind(wsp);
            return View(wsp);
        }

        readonly IConfiguration _config;

        public HomeController(IOptionsSnapshot<WebSiteProfile> options, IConfiguration config)
        {
            _options = options;
            _config = config;
        }

        public IActionResult GetEmail()
        {
            return Content(_config["email"]);
        }

        public IActionResult GetDefault()
        {
            return Content(_config["logging:logLevel:default"]);
        }
    }
}
