//���U�A�� - �L���ǩ�
using StarterM.Models;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllersWithViews();
List<Customer> _customers = new()
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

//�ϥ�Swagger�M��ɻݭn�[�W�A�� AddEndpointsApiExplorer
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(_customers);
//�����n��(middleware) - �����ǩ�
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseStaticFiles();
//app.MapDefaultControllerRoute();

//minimal api
app.MapGet("/", () =>  "Hello!");
app.MapGet("/Customer", () => new Customer
{
    CustomerID = "ALFKI",
    CompanyName = "Alfreds Futterkiste",
    Country = "Germany"
});
app.MapGet("/400", () =>  Results.BadRequest());
;

app.MapGet("/Customers", (List<Customer> customers) => customers);

app.MapGet("/Customers/{id}", (List<Customer> customers, string id) => {
    var item = customers.Find(c => c.CustomerID == id);
    if (item == null) return Results.NotFound();
    return Results.Ok(item);
});

app.Run();
//�{���i�J�I����

//Type�]�w 
