using E_Commerce.Domain.Repository.CarritoCompras;
using E_Commerce.Domain.Repository.Productos;
using E_Commerce.Domain.Repository.Usuarios;
using E_Commerce.Domain.UnitOfWorkPattern;
using E_Commerce.Infrastructure.Data;
using E_Commerce.Infrastructure.Repository.CarritoCompras;
using E_Commerce.Infrastructure.Repository.Productos;
using E_Commerce.Infrastructure.Repository.Usuarios;
using E_Commerce.Infrastructure.UnitOfWorkPattern;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnectionString")));

builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IShoppingCartRepository, ShoppinCartRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Article}/{action=Index}/{id?}");

app.Run();