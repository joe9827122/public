//���U�A�� - �L���ǩ�
using StarterM;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//�����n��(middleware) - �����ǩ�
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

//UseStaticFiles���᪽�Ǫ�^ ��X���G1 2
//�]��MVC�ɤ~��^ ��X���G 1 3 5 4 2
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
//�{���i�J�I����

//Type�]�w 
