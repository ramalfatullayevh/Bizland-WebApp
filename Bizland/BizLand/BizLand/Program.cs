using BizLand.DAL;
using Microsoft.EntityFrameworkCore;

namespace BizLand
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL")) ;
            });

            var app = builder.Build();

            app.UseRouting();
            app.UseStaticFiles();

            app.MapControllerRoute(name: "areas",pattern: "{area:exists}/{controller=Employee}/{action=Index}/{id?}");
            app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}");

            app.Run();

            //
        }
    }
}