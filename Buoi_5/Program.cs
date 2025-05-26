using Microsoft.EntityFrameworkCore;
using Buoi_5.Models;

namespace Buoi_5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Sử dụng đúng BookDBContext
            builder.Services.AddDbContext<BookDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        
            // Add services to the container
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Middleware cấu hình
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(); // ✔ Load CSS, JS...

            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
