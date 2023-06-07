//註冊服務 - 無順序性
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StarterM.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
//加入資料庫服務
builder.Services.AddDbContext<ApplicationDBContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("default"))
    );
//加入Identity服務
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().
    AddEntityFrameworkStores<ApplicationDBContext>();

//調整密碼強度設定
builder.Services.Configure<IdentityOptions>(options => {
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 1;
    options.Password.RequireDigit = false;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
});


builder.Services.ConfigureApplicationCookie(options =>
{
    //設定RememberMe cookie保存的時間
    //預設是兩周
    options.ExpireTimeSpan = TimeSpan.FromDays(1);
    //設定Login Path
    //預設為/account/login
    //options.LoginPath = "\test";
    //
    //options.AccessDeniedPath = "\ddead";
});

//中介軟體(middleware) - 有順序性
var app = builder.Build();

app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapDefaultControllerRoute();

//using (var scope = app.Services.CreateScope())
//{
//    CreateRoles(scope.ServiceProvider).Wait();
//};
app.Run();
//程式進入點結束

//Type設定 


//async Task CreateRoles(IServiceProvider serviceProvider)
//{
//    var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
//    var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
//    string[] roleNames = { "admin", "user" };

//    foreach (var roleName in roleNames)
//    {
//        var exist = await RoleManager.RoleExistsAsync(roleName);
//        if (!exist)
//        {
//            await RoleManager.CreateAsync(new IdentityRole(roleName));
//        }
//    }
//    var admin = new ApplicationUser { UserName = "admin", Email = "admin@uuu.com.tw" };
//    var user = await UserManager.FindByEmailAsync("admin@uuu.com.tw");
//    if (user == null)
//    {
//        await UserManager.CreateAsync(admin, "Pa$$w0rd");
//        await UserManager.AddToRoleAsync(admin, "admin");
//    }
//}
