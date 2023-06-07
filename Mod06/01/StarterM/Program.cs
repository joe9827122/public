//註冊服務 - 無順序性
var builder = WebApplication.CreateBuilder(args);

//亦可由appsettings.json檔案進行設定
//builder.Logging.AddFilter((category, Level) => category == "MyLog");
//builder.Logging.AddFilter((category, Level) => category == "MyLog" && Level >= LogLevel.Warning);

builder.Services.AddControllersWithViews();

//中介軟體(middleware) - 有順序性
var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
//程式進入點結束

//Type設定 
