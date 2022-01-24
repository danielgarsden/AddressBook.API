using AddressBook.Data.DbContexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Serilog;

namespace AddressBook.API
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Log.Logger = new LoggerConfiguration()
                .Enrich.WithProperty("ServerName", Environment.MachineName)
                .Enrich.WithProperty("Environment", Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production")
                .WriteTo.Console()
                .CreateBootstrapLogger();

            Log.Information("Starting up");

            IHost host = CreateHostBuilder(args).Build();

            // add a delay here to wait for the SQL Server docker container to start up before we try
            // to access it
            //System.Threading.Thread.Sleep(30000);

            // migrate the database for demo purposes
            using (IServiceScope scope = host.Services.CreateScope())
            {
                try
                {
                    AddressBookContext context = scope.ServiceProvider.GetService<AddressBookContext>();
                    //context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                }
                catch (Exception)
                {

                    throw;
                }
            }

            // run the web app
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .UseSerilog((ctx, lc) => lc.ReadFrom.Configuration(ctx.Configuration))
                .ConfigureWebHostDefaults(webBuilder =>
                {
                webBuilder.UseStartup<Startup>();
                });
        }
    }
}
