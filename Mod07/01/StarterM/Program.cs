//註冊服務 - 無順序性
using StarterM.Models;

var builder = WebApplication.CreateBuilder(args);
//MVC
builder.Services.AddControllersWithViews();

//WebAPI
//builder.Services.AddControllers();

//回傳XML資料，非必要不要開啟
//builder.Services.AddControllers(options=>
//    options.RespectBrowserAcceptHeader=true)  //讓瀏覽器可以看xml資料
//    .AddXmlSerializerFormatters(); //轉換為XML資料類型

//關閉名稱規則，預設為Javascript名稱規則
//builder.Services.AddControllers()
//    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);


List<Customer> customers = new()
{
      new Customer {
        CustomerID ="ALFKI",
        CompanyName = "Alfreds Futterkiste",
        Country ="Germany"
      } ,
      new Customer {
        CustomerID ="ANATR",
        CompanyName = "Ana Trujillo Emparedados y helados",
        Country ="Mexico"
      } ,
      new Customer {
        CustomerID = "ANTON",
        CompanyName = "Antonio Moreno Taqueria",
        Country = "Mexico"
      }
 };

builder.Services.AddSingleton(customers);

//設定Swagger服務
builder.Services.AddSwaggerGen();

//中介軟體(middleware) - 有順序性
var app = builder.Build();

//可以移除，API不會有css, js
app.UseStaticFiles();
//MVC
app.MapDefaultControllerRoute();

//使用Swagger服務
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//WebAPI
//app.MapControllers();

app.Run();
//程式進入點結束

//Type設定 
