using IKEA.DAL.Persistance.Data;
using Microsoft.EntityFrameworkCore;

namespace IKEA.PL
{
    public class Program
    {
        //Entry Point
        //1-IKEA Project Architicture (3 Tiers)
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            #region Configure Services 

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            
          
            
            //builder.Services.AddScoped<ApplicationDbContext>();
            //builder.Services.AddScoped<DbContextOptions<ApplicationDbContext>>((service) =>
            //{
            //    var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            //    optionBuilder.UseSqlServer("Server=.; Database=IKEAS_G02;trusted_Connection = true ; TrustServerCertificate = true");
            //    var options = optionBuilder.Options;

            //    return options;
            //} );
            #endregion


            var app = builder.Build();

            #region Configure Pipelines (Middle Wares)
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

            //app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            #endregion

            app.Run();
        }
    }
}
