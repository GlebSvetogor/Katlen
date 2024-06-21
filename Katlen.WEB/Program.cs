using Katlen.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Katlen.WEB.Models;
using Microsoft.Extensions.Configuration;
using Katlen.DAL.Entities;
using Katlen.BLL.DTO;
using Katlen.DAL.Implementations;
using Katlen.BLL.Interfaces;
using Katlen.BLL.Implementations;
using Katlen.BLL.AutoMapper;
using Katlen.WEB.AutoMapper;
using Katlen.DAL.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<KatlenContext>(options => options.UseSqlServer(connection, b => b.MigrationsAssembly("Katlen.WEB")));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
        options.LogoutPath = "/Account/Logout";
    });

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
builder.Services.AddScoped<ICatalog, Catalog>();
builder.Services.AddAutoMapper(typeof(AutoMapperBLL));
builder.Services.AddAutoMapper(typeof(AutoMapperWEB));

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

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

app.UseSession();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "User",
        pattern: "{controller=Account}/{action=Index}");
});


app.Run();
