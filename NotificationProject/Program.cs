using Autofac;
using Autofac.Extensions.DependencyInjection;
using BelediyeBusiness.DependencyResolvers.Autofac;
using BelediyeCore.Utilities.Security.Encryption;
using BelediyeCore.Utilities.Security.Jwt;
using BelediyeDataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));
builder.WebHost.UseIIS();

// Add services to the container.
builder.Services.AddDbContext<NotificationContext>(options =>
{
    options.UseSqlServer(
    builder.Configuration.GetConnectionString("NotificationContext"));

});
//IConfiguration config = new ConfigurationBuilder()
//    .AddJsonFile("appsettings.Production.json")
//    .AddEnvironmentVariables()
//    .Build();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient(); // IHttpClientFactory servisini ekliyoruz

builder.Services.AddRazorPages();
var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();


 builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
      .AddCookie(opts =>
      {
          opts.Cookie.Name = $".appname.auth";   // todo : de�i�tirin.
          opts.AccessDeniedPath = "/Home/Error";
          opts.LoginPath = "/Auth/Login";
          opts.SlidingExpiration = true;
      })
      .AddJwtBearer(options =>
      {
          options.RequireHttpsMetadata = false;
          options.SaveToken = true;
          options.TokenValidationParameters = new TokenValidationParameters
          {
              ValidateIssuer = false,
              ValidateAudience = false,
              ValidateLifetime = true,
              ValidateIssuerSigningKey = true,
              IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey),
              ClockSkew = TimeSpan.FromSeconds(5)
          };
      });

builder.Services.AddSession(options =>
{
    options.Cookie.Name = $"appname.session"; // todo : de�i�tirin.
    options.IdleTimeout = TimeSpan.FromMinutes(180);
    options.Cookie.IsEssential = true;
});



//builder.Services.AddAuthentication(auth=> { auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//    .AddJwtBearer(options =>
//    {
//        options.SaveToken = true;
//        options.TokenValidationParameters = new TokenValidationParameters
//        {

//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ValidIssuer = tokenOptions.Issuer,
//            ValidAudience = tokenOptions.Audience,
//            ValidateIssuerSigningKey = true,
//            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
//        };
//    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();
