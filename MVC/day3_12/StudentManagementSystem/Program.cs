using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Repositories.Interfaces;
using StudentManagementSystem.Repositories.Implementations;

namespace StudentManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            // Database Connection
            builder.Services.AddDbContext<StudentDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("StudentContext")
                ));

            // Dependency Injection
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


            var app = builder.Build();

            // HTTP Request Pipeline

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}