//註冊服務 - 無順序性
using StarterM;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllersWithViews();
//Application 層級
builder.Services.AddControllersWithViews(options=> options.Filters.Add(new MyLogAttribute()));
//中介軟體(middleware) - 有順序性
var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
//程式進入點結束

//Type設定 
