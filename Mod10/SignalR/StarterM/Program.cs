//���U�A�� - �L���ǩ�
using StarterM.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
//���USignalR�A��
builder.Services.AddSignalR();
//�����n��(middleware) - �����ǩ�
var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();
//�ϥ�SignalR�A��
app.MapHub<ChatHub>("/chat");
app.Run();
//�{���i�J�I����

//Type�]�w 
