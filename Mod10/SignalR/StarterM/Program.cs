//註冊服務 - 無順序性
using StarterM.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
//註冊SignalR服務
builder.Services.AddSignalR();
//中介軟體(middleware) - 有順序性
var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();
//使用SignalR服務
app.MapHub<ChatHub>("/chat");
app.Run();
//程式進入點結束

//Type設定 
