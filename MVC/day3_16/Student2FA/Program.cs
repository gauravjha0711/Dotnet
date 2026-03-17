using Microsoft.EntityFrameworkCore;
using Student2FA.Data;
using Student2FA.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<SmsService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

// Session service
builder.Services.AddSession();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

// Enable session
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();