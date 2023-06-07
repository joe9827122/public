//���U�A�� - �L���ǩ�
using StarterM.Models;

//��X��Output�����AShow output from �ݿ�� ASP.NET Core Web Server
Console.WriteLine((args[0], args[1]));



var builder = WebApplication.CreateBuilder(args);

Console.WriteLine(builder.Configuration["Email"]);

//�qConfig���w��ƶi�����ܧ�
//builder.Services.Configure<WebSiteProfile>(
//    p=>
//    {
//        p.Email = "config@uuu.com.tw";
//        p.ThemeColor = "LightBlue";
//    });

//�o�w��Ū���M�׳]�w�ɶi���ܧ�
//builder.Services.Configure<WebSiteProfile>(builder.Configuration);
builder.Services.Configure<WebSiteProfile>(builder.Configuration.GetSection("one:two"));


////�W�[Ū���ۭqJSON��
////Optional �w�]��False ���ɮ׬O�_�i��
////reloadOnChange �w�]��False ���ɮ׬O�_�b�ܧ�ɭ��sŪ��
//builder.Configuration.AddJsonFile("profile.json", true, true);


////�h�ӲպA�]�w�ɡA�H�̫᪺�]�w���D�C
//builder.Configuration.AddInMemoryCollection(
//    new Dictionary<string, string>
//    {
//        ["Email"]="memory@uuu.com.tw",
//        ["ThemeColor"] = "Pink"
//    });

////�W�[Ū���ۭqXML�ɮ�
//builder.Configuration.AddXmlFile("profile.xml", true, true);
////�W�[Ū���ۭqINI�ɮ�
//builder.Configuration.AddIniFile("profile.ini", true, true);

Console.WriteLine("=============================");
foreach (var item in (builder.Configuration as IConfigurationRoot).Providers)
{
    Console.WriteLine(item);
}
Console.WriteLine("=============================");

builder.Services.AddControllersWithViews();

//�����n��(middleware) - �����ǩ�
var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
//�{���i�J�I����

//Type�]�w 
