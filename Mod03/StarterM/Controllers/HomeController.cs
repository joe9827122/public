using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using StarterM.Shared;

namespace StarterM.Controllers
{
    public class HomeController : Controller
    {
        //加上底線，可以避免衝突，自動建立Constructor時不會衝突
        //需加readonly避免被換物件
        readonly IStringLocalizer<HomeController> _localizer;
        readonly IHtmlLocalizer<HomeController> _localizer2;
        readonly IStringLocalizer<Common> _localizer3;

        public HomeController(IStringLocalizer<HomeController> localizer, IHtmlLocalizer<HomeController> localizer2, IStringLocalizer<Common> localizer3)
        {
            _localizer = localizer;
            _localizer2 = localizer2;
            _localizer3 = localizer3;
        }

        [Route("WriteCookie/{culture=en-us}", Name = "Custom")]
        public IActionResult WriteCookie(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)));
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Index()
        {
            //未設定資源檔時，顯示Name
            ViewBag.Message = _localizer["greeting"];
            ViewBag.Message_No_Res = _localizer["Greeting"];
            ViewBag.Message2 = _localizer2["greeting"];
            ViewBag.Message3 = _localizer3["FileNotFound"];
            //IRequestCultureFeature需要設定中介軟體: Program.cs中須設定UseRequestLocalization()
            var feature = HttpContext.Features.Get<IRequestCultureFeature>();

            return View(feature);
        }
    }
}
