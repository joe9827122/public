//���U�A�� - �L���ǩ�
var builder = WebApplication.CreateBuilder(args);

//��i��appsettings.json�ɮ׶i��]�w
//builder.Logging.AddFilter((category, Level) => category == "MyLog");
//builder.Logging.AddFilter((category, Level) => category == "MyLog" && Level >= LogLevel.Warning);

builder.Services.AddControllersWithViews();

//�����n��(middleware) - �����ǩ�
var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
//�{���i�J�I����

//Type�]�w 
