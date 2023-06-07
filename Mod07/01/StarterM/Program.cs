//���U�A�� - �L���ǩ�
using StarterM.Models;

var builder = WebApplication.CreateBuilder(args);
//MVC
builder.Services.AddControllersWithViews();

//WebAPI
//builder.Services.AddControllers();

//�^��XML��ơA�D���n���n�}��
//builder.Services.AddControllers(options=>
//    options.RespectBrowserAcceptHeader=true)  //���s�����i�H��xml���
//    .AddXmlSerializerFormatters(); //�ഫ��XML�������

//�����W�ٳW�h�A�w�]��Javascript�W�ٳW�h
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

//�]�wSwagger�A��
builder.Services.AddSwaggerGen();

//�����n��(middleware) - �����ǩ�
var app = builder.Build();

//�i�H�����AAPI���|��css, js
app.UseStaticFiles();
//MVC
app.MapDefaultControllerRoute();

//�ϥ�Swagger�A��
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//WebAPI
//app.MapControllers();

app.Run();
//�{���i�J�I����

//Type�]�w 
