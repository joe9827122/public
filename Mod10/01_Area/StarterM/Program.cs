//���U�A�� - �L���ǩ�
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//�����n��(middleware) - �����ǩ�
var app = builder.Build();

app.UseStaticFiles();
app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );
app.MapDefaultControllerRoute();

app.Run();
//�{���i�J�I����

//Type�]�w 
