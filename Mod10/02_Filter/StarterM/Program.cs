//���U�A�� - �L���ǩ�
using StarterM;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllersWithViews();
//Application �h��
builder.Services.AddControllersWithViews(options=> options.Filters.Add(new MyLogAttribute()));
//�����n��(middleware) - �����ǩ�
var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
//�{���i�J�I����

//Type�]�w 
