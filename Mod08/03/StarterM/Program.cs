//���U�A�� - �L���ǩ�
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//�����n��(middleware) - �����ǩ�
var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
//�{���i�J�I����

//Type�]�w 
