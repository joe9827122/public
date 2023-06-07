//註冊服務 - 無順序性
using Microsoft.Extensions.FileProviders;
using StarterM;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
//每注入一次會產生一個物件
//每個物件在Request結束時執行Dispose
//builder.Services.AddTransient<IMyService, MyService>();
//同一個Request只會產生一個Service
//Request結束時執行Dispose
//builder.Services.AddScoped<IMyService, MyService>();
//整個Application只有一個Service
//Application關閉時才會進行Dispose
//builder.Services.AddSingleton<IMyService, MyService>();

//關閉持不會進行Dispose
//IMyService service = new MyService();
//builder.Services.AddSingleton(service);
//builder.Services.AddSingleton<IMyService>(service);

//透過Using進行Dispose
using var service1 = new MyService();
builder.Services.AddSingleton<IMyService>(service1);

//FileProvider
//1. 存取Content Root目錄
var p1 = builder.Environment.ContentRootFileProvider;
//builder.Services.AddSingleton(p1);
//2.EmbeddedFileProvider
//可以使用ildasm工具反組譯查看是否為內嵌文字檔
var p2 = new EmbeddedFileProvider(typeof(Program).Assembly);
//builder.Services.AddSingleton<IFileProvider>(p2);
//3.CompositeFileProvider
var p3 = new CompositeFileProvider(p1, p2);
builder.Services.AddSingleton<IFileProvider>(p3);

//中介軟體(middleware) - 有順序性
var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
//程式進入點結束

//Type設定 
