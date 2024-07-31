using Microsoft.AspNetCore.Http.Connections;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ShopProjectMVC.Attributes;
using ShopProjectMVC.Controllers;
using ShopProjectMVC.Core.Interfaces;
using ShopProjectMVC.Core.Services;
using ShopProjectMVC.Storage;
using ShopProjectMVC.Storage.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Local");

builder.Services.AddDbContext<ShopProjectContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IRepository, GenericRepository>();

builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromSeconds((int)builder.Configuration.GetValue(typeof(int), "SessionTimeout"));
	options.Cookie.HttpOnly = true;
	options.Cookie.IsEssential = true;
});


builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new SessionCheckAttribute());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();


/*
 - buy product (create order)
 - view products (get products)
 - login/register (get/create user)
 - sorting/filter (products)
 - view orders (get orders)
 - view orders with limits
 - add product
 - remove product
 - update product
 */