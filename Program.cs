using Base.Enums;
using Base.Models;
using Base.Services;
using BaseWeb.Services;
using EarthFront.Data;
using EarthFront.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

//1.config MVC
services.AddControllersWithViews()
    //view Localization
    //.AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    //use pascal for newtonSoft json
    .AddNewtonsoftJson(opts => { opts.UseMemberCasing(); })
    //use pascal for MVC json
    .AddJsonOptions(opts => { opts.JsonSerializerOptions.PropertyNamingPolicy = null; });

//2.set Resources path
//services.AddLocalization(opts => opts.ResourcesPath = "Resources");

//3.http context
services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//4.user info for base component
services.AddSingleton<IBaseUserService, MyBaseUserService>();

//5.ado.net for mssql
services.AddTransient<DbConnection, SqlConnection>();
services.AddTransient<DbCommand, SqlCommand>();

//6.appSettings "FunConfig" section -> _Fun.Config
var config = new ConfigDto();
builder.Configuration.GetSection("FunConfig").Bind(config);
_Fun.Config = config;

/*
//7.session (memory cache)
services.AddDistributedMemoryCache();
//services.AddStackExchangeRedisCache(opts => { opts.Configuration = "127.0.0.1:6379"; });
services.AddSession(opts =>
{
    opts.Cookie.HttpOnly = true;
    opts.Cookie.IsEssential = true;
    opts.IdleTimeout = TimeSpan.FromMinutes(60);
});
*/
//jwt�{��
services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opts =>
    {
        opts.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,  //�O�_���ҶW��  ��]�mexp�Mnbf�ɦ��� 
            ValidateIssuerSigningKey = true,  //�O�_���ұK�_
            //ValidAudience = "http://localhost:49999",//Audience
            //ValidIssuer = "http://localhost:49998",//Issuer�A�o�ⶵ�M�n�J�ɹ{�o���@�P
            IssuerSigningKey = _Xp.GetJwtKey(),     //SecurityKey
            //�w�ĹL���ɶ��A�`�����Įɶ�����o�Ӯɶ��[�Wjwt���L���ɶ��A�w�]��5����                                                                                                            //�`�N�o�O�w�ĹL���ɶ��A�`�����Įɶ�����o�Ӯɶ��[�Wjwt���L���ɶ��A�p�G���t�m�A�q�{�O5����
            //ClockSkew = TimeSpan.FromMinutes(60)   //�]�m�L���ɶ�
        };
    })
    .AddGoogle(opts =>
    {
        //var auth = builder.Configuration.GetSection("Authentication:Google");
        opts.ClientId = _Fun.Config.GoogleClientId;
        opts.ClientSecret = _Fun.Config.GoogleClientSecret;
    });
/*
.AddFacebook(opts =>
{
    opts.ClientId = _Fun.Config.FbClientId;
    opts.ClientSecret = _Fun.Config.FbClientSecret;
});
*/

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
/*
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
*/
builder.Services.AddControllersWithViews();

var app = builder.Build();

//initial & set locale
var isDev = app.Environment.IsDevelopment();
_Fun.Init(isDev, app.Services, DbTypeEnum.MSSql);
_Locale.SetCultureAsync(_Fun.Config.Locale);


// Configure the HTTP request pipeline.
if (isDev)
{
    app.UseMigrationsEndPoint();
    app.UseDeveloperExceptionPage();
    //app.UseExceptionHandler("/Home/Error");
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//app.MapRazorPages();

app.Run();
