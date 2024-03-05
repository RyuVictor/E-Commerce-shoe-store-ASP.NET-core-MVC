using eCommerce.Dal;
using eCommerce.Models;
using eCommerce_.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("StripeSettings"));
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme =  CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
}).AddGoogle(options =>
{
    IConfigurationSection googleAuthNSection =
    builder.Configuration.GetSection("Authentication:Google");
    options.ClientId = googleAuthNSection["ClientId"];
    options.ClientSecret = googleAuthNSection["ClientSecret"];
    options.ClaimActions.MapJsonKey("urn:google:picture", "picture");
    options.ClaimActions.MapJsonKey("urn:google:email", "email");
}).AddCookie();

builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(20);
    option.Cookie.IsEssential = true;
    option.Cookie.HttpOnly = true;
});

//builder.Services.AddDbContext<ECommerceDbContext>(options =>
//{
//    options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase"));
//});
builder.Services.AddDbContext<ECommerceDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("eCommerceConStr"));
});
builder.Services.AddTransient<ICommonRepository<Product>,CommonRepository<Product>>();
builder.Services.AddTransient<ICommonRepository<Category>, CommonRepository<Category>>();
builder.Services.AddTransient<ICommonRepository<CartDetail>, CommonRepository<CartDetail>>();
builder.Services.AddTransient<INewCartRepository, NewCartRepository>();
builder.Services.AddControllersWithViews();

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
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoint =>
{
    endpoint.MapAreaControllerRoute(
            name: "Employees",
            areaName: "Employees",
            pattern: "Employees/{controller=Home}/{action=Index}/{id?}"
          );
    endpoint.MapAreaControllerRoute(
            name: "CartsManager",
            areaName: "Carts",
            pattern: "Carts/{controller=Home}/{action=MyCart}/{id?}"
          );
    endpoint.MapAreaControllerRoute(
            name: "Customers",
            areaName: "Customers",
            pattern: "Customers/{controller=Home}/{action=Index}/{id?}"
          );
    endpoint.MapAreaControllerRoute(
            name: "CategoriesManager",
            areaName: "Categories",
            pattern: "Categories/{controller=Home}/{action=Index}/{id?}"
          );
    endpoint.MapAreaControllerRoute(
            name: "Products",
            areaName: "Products",
            pattern: "Products/{controller=Home}/{action=Index}/{id?}"
          );
    endpoint.MapAreaControllerRoute(
        name: "SecurityManager",
        areaName: "Security",
        pattern: "Security/{controller=Home}/{action=Login}/{id?}"
      );
    endpoint.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
