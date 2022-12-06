using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build(); //Skapar en variabel för build och tar bort run()
            using var scope = host.Services.CreateScope(); //Skapar ett scope som hostar any services som vi skapar innuti denna metod. 
            var services = scope.ServiceProvider;

            try { //Kommer köra detta när vi startar programmet och köra detta om vi inte redan har en databas.
                var context = services.GetRequiredService<DataContext>(); //Vi får DataContext som en server för vi har addat det i vår startup.cs fil.
                await context.Database.MigrateAsync(); //Kör migration och skapar databasen.
                await Seed.SeedData(context); //Stoppar in context som argument 

            } catch(Exception ex) {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occured during migration");

            }

            await host.RunAsync(); //Detta kör programmet VIKTIGT! 
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
