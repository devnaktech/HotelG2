using LMC103.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<DapperFactory>();

var connectionString = builder.Configuration.GetConnectionString("Docker")
    ?? throw new Exception("invalid Connectionstring");

Console.WriteLine($"Using Connection String: {connectionString}"); // Debugging



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