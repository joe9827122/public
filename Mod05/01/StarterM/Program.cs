//���U�A�� - �L���ǩ�
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StarterM.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
//�[�J��Ʈw�A��
builder.Services.AddDbContext<ApplicationDBContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("default"))
    );
//�[�JIdentity�A��
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().
    AddEntityFrameworkStores<ApplicationDBContext>();

//�վ�K�X�j�׳]�w
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
    //�]�wRememberMe cookie�O�s���ɶ�
    //�w�]�O��P
    options.ExpireTimeSpan = TimeSpan.FromDays(1);
    //�]�wLogin Path
    //�w�]��/account/login
    //options.LoginPath = "\test";
    //
    //options.AccessDeniedPath = "\ddead";
});

//�����n��(middleware) - �����ǩ�
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
//�{���i�J�I����

//Type�]�w 


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
