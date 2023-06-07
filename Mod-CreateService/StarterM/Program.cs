//���U�A�� - �L���ǩ�
using Microsoft.Extensions.FileProviders;
using StarterM;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
//�C�`�J�@���|���ͤ@�Ӫ���
//�C�Ӫ���bRequest�����ɰ���Dispose
//builder.Services.AddTransient<IMyService, MyService>();
//�P�@��Request�u�|���ͤ@��Service
//Request�����ɰ���Dispose
//builder.Services.AddScoped<IMyService, MyService>();
//���Application�u���@��Service
//Application�����ɤ~�|�i��Dispose
//builder.Services.AddSingleton<IMyService, MyService>();

//���������|�i��Dispose
//IMyService service = new MyService();
//builder.Services.AddSingleton(service);
//builder.Services.AddSingleton<IMyService>(service);

//�z�LUsing�i��Dispose
using var service1 = new MyService();
builder.Services.AddSingleton<IMyService>(service1);

//FileProvider
//1. �s��Content Root�ؿ�
var p1 = builder.Environment.ContentRootFileProvider;
//builder.Services.AddSingleton(p1);
//2.EmbeddedFileProvider
//�i�H�ϥ�ildasm�u��ϲ�Ķ�d�ݬO�_�����O��r��
var p2 = new EmbeddedFileProvider(typeof(Program).Assembly);
//builder.Services.AddSingleton<IFileProvider>(p2);
//3.CompositeFileProvider
var p3 = new CompositeFileProvider(p1, p2);
builder.Services.AddSingleton<IFileProvider>(p3);

//�����n��(middleware) - �����ǩ�
var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
//�{���i�J�I����

//Type�]�w 
