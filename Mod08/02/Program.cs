using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StarterM.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSession();
builder.Services.AddDbContext<OperaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OperaContext") ?? throw new InvalidOperationException("Connection string 'OperaContext' not found.")));
builder.Services.AddControllersWithViews();
//==================================
var app = builder.Build();
app.UseStaticFiles();
app.UseSession();
app.MapDefaultControllerRoute();
app.Run();
