using HotelG2.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<DapperFactory>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new Exception("invalid Connectionstring");

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(connectionString);
});

var app = builder.Build();
app.UseStaticFiles();

app.UseRouting();
app.MapDefaultControllerRoute();
//app.MapGet("/", () => "Hello World!");

app.Run();