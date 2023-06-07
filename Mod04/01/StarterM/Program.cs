//註冊服務 - 無順序性
using StarterM.Models;

//輸出到Output視窗，Show output from 需選擇 ASP.NET Core Web Server
Console.WriteLine((args[0], args[1]));



var builder = WebApplication.CreateBuilder(args);

Console.WriteLine(builder.Configuration["Email"]);

//從Config指定資料進行資料變更
//builder.Services.Configure<WebSiteProfile>(
//    p=>
//    {
//        p.Email = "config@uuu.com.tw";
//        p.ThemeColor = "LightBlue";
//    });

//這定為讀取專案設定檔進行變更
//builder.Services.Configure<WebSiteProfile>(builder.Configuration);
builder.Services.Configure<WebSiteProfile>(builder.Configuration.GetSection("one:two"));


////增加讀取自訂JSON檔
////Optional 預設為False 為檔案是否可選
////reloadOnChange 預設為False 為檔案是否在變更時重新讀取
//builder.Configuration.AddJsonFile("profile.json", true, true);


////多個組態設定時，以最後的設定為主。
//builder.Configuration.AddInMemoryCollection(
//    new Dictionary<string, string>
//    {
//        ["Email"]="memory@uuu.com.tw",
//        ["ThemeColor"] = "Pink"
//    });

////增加讀取自訂XML檔案
//builder.Configuration.AddXmlFile("profile.xml", true, true);
////增加讀取自訂INI檔案
//builder.Configuration.AddIniFile("profile.ini", true, true);

Console.WriteLine("=============================");
foreach (var item in (builder.Configuration as IConfigurationRoot).Providers)
{
    Console.WriteLine(item);
}
Console.WriteLine("=============================");

builder.Services.AddControllersWithViews();

//中介軟體(middleware) - 有順序性
var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
//程式進入點結束

//Type設定 
