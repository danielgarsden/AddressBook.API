using AddressBook.Worker;
using AddressBook.Data.Services;
using AddressBook.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddHostedService<Worker>();
        //services.AddScoped<IServiceProvider, ServiceProvider>();
        services.AddScoped<IAddressBookAuditRepository, AddressBookAuditRepository>();

        // set up database connection string
        var server = context.Configuration["AddressBookDB:DBServer"] ?? "localhost";
        var port = context.Configuration["AddressBookDB:DBPort"] ?? "";
        var user = context.Configuration["AddressBookDB:DBUser"] ?? "User";
        var password = context.Configuration["AddressBookDB:DBPassword"] ?? "password";
        var database = context.Configuration["AddressBookDB:DBDatabase"] ?? "AddressBookDB";
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
    })
    .Build();

await host.RunAsync();
