using Auth_Login.AuthenticateLoginRepositories;
using Auth_Login.Models;
using Microsoft.EntityFrameworkCore;
namespace Auth_Login
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<Models.LoginDbcontext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStr"));
            });

            builder.Services.AddScoped<IAuthenticateLogin, AuthenticateLogin>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
