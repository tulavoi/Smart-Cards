using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartCards.Areas.Identity.Data;
using SmartCards.Interfaces;
using SmartCards.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'AppDbContextConnection' not found.");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDefaultIdentity<AppUser>()
     .AddEntityFrameworkStores<AppDbContext>()
     .AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.ConfigureApplicationCookie(options => {
    options.LoginPath = "/login/";
    options.LogoutPath = "/logout/";
});

// Configuartion login
builder.Services.AddAuthentication()
.AddGoogle(options =>
{
    var gconfig = builder.Configuration.GetSection("Authentication:Google");
    options.ClientId = gconfig["GoogleOAuthClientId"]!;
    options.ClientSecret = gconfig["GoogleOAuthClientSec"]!;
    options.CallbackPath = "/signin-google";
})
.AddFacebook(options =>
{
    var fconfig = builder.Configuration.GetSection("Authentication:Facebook");
    options.AppId = fconfig["AppId"]!;
    options.AppSecret = fconfig["AppSec"]!;
    //options.CallbackPath = "/login";
});
builder.Services.AddAuthorization();

// Đăng ký service cho interfaces
builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICoursePermissionRepository, CoursePermissionRepository>();
builder.Services.AddScoped<IFlashcardRepository, FlashcardRepository>();

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

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
