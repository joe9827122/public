//註冊服務 - 無順序性
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
//註冊Session服務，預設未開啟
builder.Services.AddSession();

//中介軟體(middleware) - 有順序性
var app = builder.Build();

app.UseStaticFiles();
app.UseSession(); // 需加在MVC之前
app.MapDefaultControllerRoute(); // MVC

app.Run();
//程式進入點結束

//Type設定 
