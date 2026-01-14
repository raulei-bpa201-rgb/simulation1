using simiulationraul.DAL;
using Microsoft.EntityFrameworkCore;

namespace simiulationraul
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(ops => ops.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            app.UseStaticFiles();

			app.MapControllerRoute(
				name: "admin",
				pattern: "{area:exists}/{controller=Home}/{action=Index}"
			);

			app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );

            

            app.Run();
        }
    }
}
