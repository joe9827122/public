//註冊服務 - 無順序性
using System.Net.Mime;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StarterM.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<OperaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OperaContext") ?? throw new InvalidOperationException("Connection string 'OperaContext' not found.")));

builder.Services.AddControllersWithViews();

//中介軟體(middleware) - 有順序性
var app = builder.Build();

//開發時的EnvironmentName設定在兩處
//1. Debug->"Project Name" Debug Properties
//2. Solution Explorer -> Properties -> launchSettings.json
//將EnvironmentName切換模擬設定為Production
app.Environment.EnvironmentName = Environments.Production;

//若省略，只會顯示錯誤碼的狀態 Error code : 500
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    //進行重新轉向，開發者工具察看到的是Status Code 302
    //app.UseStatusCodePagesWithRedirects("/StatusCode?code={0}");
    //重新執行，status Code 404
    app.UseStatusCodePagesWithReExecute("/StatusCode","?code={0}");
}
else
{
    app.UseStatusCodePages(MediaTypeNames.Text.Html, "<h1>StatusCode: {0}</h1>");
    //app.UseStatusCodePages();
}

app.UseStaticFiles();
// Custom Route: "/OperaTitle/Rigoletto"
// 此方法的客製化路徑與原路徑規則皆可以使用
//app.MapControllerRoute("Custom", "OperaTitle/{title}", 
//    new {controller="Operas", action="DetailsByTitle"});
app.MapDefaultControllerRoute();

app.Run();
//程式進入點結束

//Type設定 
