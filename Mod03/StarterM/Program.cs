//���U�A�� - �L���ǩ�
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//IViewLocalizer, IHtmlLocalizer�A�ȵ��U
builder.Services.AddControllersWithViews().AddDataAnnotationsLocalization().AddViewLocalization(); 
//IStringLocalizer�A�ȵ��U
//builder.Services.AddLocalization();
builder.Services.AddLocalization(options=>options.ResourcesPath="Resources");

//�����n��(middleware) - �����ǩ�
var app = builder.Build();

var supportedCultures = new[]
{
    new CultureInfo("en-US"),
    new CultureInfo("zh-TW"),
};
//�W�[���a�Ƴ]�w
//���a�ƻy�����s�������y���u������
//app.UseRequestLocalization(new RequestLocalizationOptions
//{
//    DefaultRequestCulture=new Microsoft.AspNetCore.Localization.RequestCulture("en-US"),
//    SupportedCultures=supportedCultures,
//    SupportedUICultures=supportedCultures,
//});

//RouteDataRequestCultureProvider �]�w
var options = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("zh-tw"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
};
//RouteDataRequestCultureProvider�]RequestCultureProvider.Insert���w���J����m�M�w���a�ƻy�����u������
options.RequestCultureProviders.Insert(0, new RouteDataRequestCultureProvider());
app.UseRequestLocalization(options);
app.MapControllerRoute("culture",
      "{culture=en-us}/{controller=Home}/{action=Index}/{id?}");
//RouteDataRequestCultureProvider �]�w End


app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
//�{���i�J�I����

//Type�]�w 
