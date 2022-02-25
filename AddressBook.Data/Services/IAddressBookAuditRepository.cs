using AddressBook.Data.Entities;
using System.Collections.Generic;

namespace AddressBook.Data.Services
{
    public interface IAddressBookAuditRepository
    {
        /// <summary>
        /// Gets All AddressAudits that are waiting to be sent
        /// </summary>
        /// <returns></returns>
        IEnumerable<AddressAudit> GetAddressAuditsToBeSent();

        /// <summary>
        /// Update an AddressAudit Entry
        /// </summary>
        /// <param name="addressAudit"></param>
        void UpdateAddressAudit(AddressAudit addressAudit);

        /// <summary>
        /// Save the changes
        /// </summary>
        /// <returns>bool as the whether the save was sucessful or not</returns>
        bool Save();
    }
}
