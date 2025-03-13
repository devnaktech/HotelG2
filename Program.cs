using Midterm.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Midterm.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUserService, UserServiceImpl>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
  options.LogoutPath = new PathString("/Account/Login");
  options.AccessDeniedPath = new PathString("/Account/AccessDenied");
  options.ReturnUrlParameter = "ReturnUrl";
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); 
}
else
{
    app.UseDeveloperExceptionPage();
}


app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
