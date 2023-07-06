using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DataTableTest.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<OperaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OperaContext") ?? throw new InvalidOperationException("Connection string 'OperaContext' not found.")));
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapDefaultControllerRoute();
app.Run();
