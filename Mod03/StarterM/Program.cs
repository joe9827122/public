//註冊服務 - 無順序性
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//IViewLocalizer, IHtmlLocalizer服務註冊
builder.Services.AddControllersWithViews().AddDataAnnotationsLocalization().AddViewLocalization(); 
//IStringLocalizer服務註冊
//builder.Services.AddLocalization();
builder.Services.AddLocalization(options=>options.ResourcesPath="Resources");

//中介軟體(middleware) - 有順序性
var app = builder.Build();

var supportedCultures = new[]
{
    new CultureInfo("en-US"),
    new CultureInfo("zh-TW"),
};
//增加本地化設定
//本地化語言為瀏覽器的語言優先順序
//app.UseRequestLocalization(new RequestLocalizationOptions
//{
//    DefaultRequestCulture=new Microsoft.AspNetCore.Localization.RequestCulture("en-US"),
//    SupportedCultures=supportedCultures,
//    SupportedUICultures=supportedCultures,
//});

//RouteDataRequestCultureProvider 設定
var options = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("zh-tw"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
};
//RouteDataRequestCultureProvider因RequestCultureProvider.Insert指定插入的位置決定本地化語言的優先順序
options.RequestCultureProviders.Insert(0, new RouteDataRequestCultureProvider());
app.UseRequestLocalization(options);
app.MapControllerRoute("culture",
      "{culture=en-us}/{controller=Home}/{action=Index}/{id?}");
//RouteDataRequestCultureProvider 設定 End


app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
//程式進入點結束

//Type設定 
