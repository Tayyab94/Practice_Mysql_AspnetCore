using Microsoft.EntityFrameworkCore;
using Mysql.Models;
using Mysql.Models.Repos;

var builder = WebApplication.CreateBuilder(args);



//string mySqlConnectionStr = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<DemoContext>(options =>
//{
//    // First Opetionis to give the Connection String, Second is Server servio.
//    options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr));
//});

// Alternative way to Add Connection string.

builder.Services.AddDbContext<demoContext>(options => options.UseMySql(builder.
                Configuration.GetConnectionString("DefaultConnection"),new MySqlServerVersion(new Version(8,0,22))));


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
