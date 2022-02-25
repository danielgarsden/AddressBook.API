using AddressBook.Data.Entities;
using AddressBook.Data.Services;

namespace AddressBook.Worker
{
    public class Worker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        private readonly ILogger<Worker> _logger;

        public Worker(IServiceProvider serviceProvider, ILogger<Worker> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                var scope = _serviceProvider.CreateScope();
                IAddressBookAuditRepository repo = scope.ServiceProvider.GetRequiredService<IAddressBookAuditRepository>();

                ProcessAddressAudits process = new ProcessAddressAudits(repo, _logger);
                IEnumerable<AddressAudit> addressAudits = process.Process();
                if (addressAudits.Count() == 0)
                {
                    _logger.LogInformation("O address audits records processed");
                }

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}