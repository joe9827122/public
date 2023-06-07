//註冊服務 - 無順序性
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    //快取60秒
    options.CacheProfiles.Add("default", new()
    {
        Duration = 60
    });

    //不使用快取
    options.CacheProfiles.Add("never", new()
    {
        Location=ResponseCacheLocation.None,
        NoStore = true
    });
});
builder.Services.AddResponseCaching();
//中介軟體(middleware) - 有順序性
var app = builder.Build();

app.UseStaticFiles();
app.UseResponseCaching();
app.MapDefaultControllerRoute();

app.Run();
//程式進入點結束

//Type設定 
