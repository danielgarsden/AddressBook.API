using AddressBook.API.DbContexts;
using AddressBook.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace AddressBook.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // setup soome http response codes that all controller methods can return
            services.AddControllers(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;
                setupAction.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest));
                setupAction.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status406NotAcceptable));
                setupAction.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));
            });

            // inform that the dependency injection controller that AddressBookRepository should be used where an implementation IAddressBookRepository is needed
            services.AddScoped<IAddressBookRepository, AddressBookRepository>();
            services.AddApiVersioning(option => option.AssumeDefaultVersionWhenUnspecified = true); ;

            // set up database connetion string
            var server = Configuration["AddressBookDB:DBServer"] ?? "localhost";
            var port = Configuration["AddressBookDB:DBPort"] ?? "";
            var user = Configuration["AddressBookDB:DBUser"] ?? "User";
            var password = Configuration["AddressBookDB:DBPassword"] ?? "password";
            var database = Configuration["AddressBookDB:DBDatabase"] ?? "AddressBookDB";
            var connectionString = "";

            if (port == "")
            {
                connectionString = $"Server={server};Database={database};User={user};Password={password};";
            }
            else
            { 
                connectionString = $"Server={server},{port};Database={database};User={user};Password={password};";
            }

            // configure Database
            services.AddDbContext<AddressBookContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            // configure Swagger for API documentation
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "AddressBook.API",
                    Version = "v1",
                    Description = "API to create, read update and delete Address Book Entries"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AddressBook.API v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
