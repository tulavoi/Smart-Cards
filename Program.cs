using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartCards.Areas.Identity.Data;

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
