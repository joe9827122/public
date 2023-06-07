//���U�A�� - �L���ǩ�
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    //�֨�60��
    options.CacheProfiles.Add("default", new()
    {
        Duration = 60
    });

    //���ϥΧ֨�
    options.CacheProfiles.Add("never", new()
    {
        Location=ResponseCacheLocation.None,
        NoStore = true
    });
});
builder.Services.AddResponseCaching();
//�����n��(middleware) - �����ǩ�
var app = builder.Build();

app.UseStaticFiles();
app.UseResponseCaching();
app.MapDefaultControllerRoute();

app.Run();
//�{���i�J�I����

//Type�]�w 
