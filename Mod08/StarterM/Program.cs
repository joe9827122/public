//���U�A�� - �L���ǩ�
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
//���USession�A�ȡA�w�]���}��
builder.Services.AddSession();

//�����n��(middleware) - �����ǩ�
var app = builder.Build();

app.UseStaticFiles();
app.UseSession(); // �ݥ[�bMVC���e
app.MapDefaultControllerRoute(); // MVC

app.Run();
//�{���i�J�I����

//Type�]�w 
