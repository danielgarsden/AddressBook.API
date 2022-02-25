using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Data.Services;
using AddressBook.Data.Entities;

namespace AddressBook.Worker
{
    public class ProcessAddressAudits
    {
        private readonly IAddressBookAuditRepository _addressBookAuditRepository;

        private readonly ILogger<Worker> _logger;

        public ProcessAddressAudits(IAddressBookAuditRepository addressBookAuditRepository, ILogger<Worker> logger)
        {
            _addressBookAuditRepository = addressBookAuditRepository;
            _logger = logger;
        }
        public IEnumerable<AddressAudit> Process()
        {
            
            IEnumerable<AddressAudit> addressAudits = _addressBookAuditRepository.GetAddressAuditsToBeSent();

            foreach (AddressAudit audit in addressAudits)
            {
                audit.AddressToBeSent = null;
                audit.AddressSentAt = DateTime.Now;
                _addressBookAuditRepository.UpdateAddressAudit(audit);
                _addressBookAuditRepository.Save();
            }

            return addressAudits;
        }

        private bool SendToQueue(AddressAudit audit)
        {
            return true;
        }
    }
}
