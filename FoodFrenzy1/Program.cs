using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FoodFrenzy1.Data;
using Microsoft.AspNetCore.Identity;
namespace FoodFrenzy1
{
    public class Program
    {
        //public static void Main(string[] args)
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<FoodFrenzy1Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("FoodFrenzy1Context") ?? throw new InvalidOperationException("Connection string 'FoodFrenzy1Context' not found.")));

            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<FoodFrenzy1Context>()
    .AddDefaultTokenProviders();

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<FoodFrenzy1.Models.Cart>();

            var app = builder.Build();

            // Seed the database
            await SeedDatabaseAsync(app);

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=User}/{action=SignUp}/{id?}");

            app.Run();
        }
        private static async Task SeedDatabaseAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    await SeedData.Initialize(services);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred seeding the DB: {ex.Message}");
                }
            }
        }
    }
}
