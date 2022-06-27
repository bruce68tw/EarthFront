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
//jwt認證
services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opts =>
    {
        opts.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,  //是否驗證超時  當設置exp和nbf時有效 
            ValidateIssuerSigningKey = true,  //是否驗證密鑰
            //ValidAudience = "http://localhost:49999",//Audience
            //ValidIssuer = "http://localhost:49998",//Issuer，這兩項和登入時頒發的一致
            IssuerSigningKey = _Xp.GetJwtKey(),     //SecurityKey
            //緩衝過期時間，總的有效時間等於這個時間加上jwt的過期時間，預設為5分鐘                                                                                                            //注意這是緩衝過期時間，總的有效時間等於這個時間加上jwt的過期時間，如果不配置，默認是5分鐘
            //ClockSkew = TimeSpan.FromMinutes(60)   //設置過期時間
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
