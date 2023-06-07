using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StarterM;
using StarterM.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<OperaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OperaContext") ?? throw new InvalidOperationException("Connection string 'OperaContext' not found.")));
//builder.Services.AddControllersWithViews(options => options.Filters.Add<MyLogAttritube>());
//Service Filter
builder.Services.AddControllersWithViews(options => options.Filters.AddService<MyLogAttritube>());
builder.Services.AddScoped<MyLogAttritube>();
//==================================
var app = builder.Build();
app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.Run();
