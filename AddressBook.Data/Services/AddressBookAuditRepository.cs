using AddressBook.Data.DbContexts;
using AddressBook.Data.Entities;
using AddressBook.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBook.Data.Services
{
    public class AddressBookAuditRepository : IAddressBookAuditRepository
    {
        // field to hold the persistance context, all interactions with the database will happen through this
        private readonly AddressBookContext _context;

        /// <summary>
        /// Constructor that receives the persistence context
        /// </summary>
        /// <param name="context"></param>
        public AddressBookAuditRepository(AddressBookContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IEnumerable<AddressAudit> GetAddressAuditsToBeSent()
        {
            return _context.AddressBooksAudit.Where(a => a.AddressToBeSent != null);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateAddressAudit(AddressAudit addressAudit)
        {
            // No Code implementation
        }
    }
}
