//註冊服務 - 無順序性
using StarterM;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//中介軟體(middleware) - 有順序性
var app = builder.Build();

//app.Map("/UseTest", app2 => app2.Use(async (context, next)=> 
//{
//    await context.Response.WriteAsync("UseTest");
//    await next(context);
//}));
//app.Map("/sayhello", app2 => app2.Run(async context => await context.Response.WriteAsync("Hello")));
//app.Map("/sayhi", app2 => app2.Run(async context => await context.Response.WriteAsync("Hi")));
//app.Run(async context => await context.Response.WriteAsync("End"));


//app.UseGreeting();
//app.Run(async context => await context.Response.WriteAsync("End"));

//UseStaticFiles找到後直些返回 輸出結果1 2
//跑到MVC時才返回 輸出結果 1 3 5 4 2
//app.Use(async (context, next) =>
//{
//    Console.WriteLine(0);
//    await next(context);
//    Console.WriteLine(6);
//});
app.UseMiddleware1();
app.UseStaticFiles();
app.UseMiddleware2();
app.MapDefaultControllerRoute();

app.Run();
//程式進入點結束

//Type設定 
