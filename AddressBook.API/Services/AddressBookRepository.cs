using AddressBook.API.DbContexts;
using AddressBook.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBook.API.Services
{
    /// <summary>
    /// Repository for AddressBook records
    /// </summary>
    public class AddressBookRepository : IAddressBookRepository
    {
        // field to hold the persistance context, all interactions with the database will happen through this
        private readonly AddressBookContext _context;

        /// <summary>
        /// Constructor that receives the persistence context
        /// </summary>
        /// <param name="context"></param>
        public AddressBookRepository(AddressBookContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Add an Address
        /// </summary>
        /// <param name="addressBook">The AddressBook Entity to add</param>
        public void AddAddress(Address addressBook)
        {
            if (addressBook == null)
            {
                throw new ArgumentNullException(nameof(addressBook));
            }

            AddressAudit audit = MapAddressToAddressAudit(addressBook);
            addressBook.AddressAudit.Add(audit);
            _context.AddressBooks.Add(addressBook);
        }


        /// <summary>
        /// Check of the address exisits
        /// </summary>
        /// <param name="addressBookId">The Id of the AddressBook entity to check</param>
        /// <returns>bool as to whether the address already exists</returns>
        public bool AddressExists(int addressId)
        {
            return _context.AddressBooks.Where(a => a.Deleted == false).Any(a => a.AddressId == addressId);
        }

        /// <summary>
        /// Delete an Address
        /// </summary>
        /// <param name="addressBook">The AddressBook Entity to delete</param>
        public void DeleteAddress(Address addressBook)
        {
            if (addressBook == null)
            {
                throw new ArgumentNullException(nameof(addressBook));
            }

            addressBook.Deleted = true;

            AddressAudit audit = MapAddressToAddressAudit(addressBook);
            addressBook.AddressAudit.Add(audit);
        }

        /// <summary>
        /// Get an AddressBook entity
        /// </summary>
        /// <param name="addressBookId">The Id of the AddressBook entity to check</param>
        /// <returns>An AddressBook entity</returns>
        public Address GetAddress(int addressId)
        {
            return _context.AddressBooks.Where(a => a.Deleted == false).FirstOrDefault(a => a.AddressId == addressId);
        }

        /// <summary>
        /// Get all AddressBook Entities
        /// </summary>
        /// <returns>IEnumerable of AddressBook Entities</returns>
        public IEnumerable<Address> GetAddresses()
        {
            return _context.AddressBooks.ToList<Address>().Where(a => a.Deleted == false);
        }

        /// <summary>
        /// Save anys changes to the persistance context
        /// </summary>
        /// <returns>bool as the whether the save was sucessful or not </returns>
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        /// <summary>
        /// Update an Address
        /// </summary>
        /// <param name="addressBook">The AddressBook Entity to update</param>
        public void UpdateAddress(Address addressBook)
        {
            AddressAudit audit = MapAddressToAddressAudit(addressBook);
            addressBook.AddressAudit.Add(audit);
        }

        /// <summary>
        /// Create an AddressBookAudit entity from an AddressBook entity
        /// </summary>
        /// <param name="address"></param>
        /// <param name="delete"></param>
        /// <returns></returns>
        private static AddressAudit MapAddressToAddressAudit(Address address)
        {
            AddressAudit audit = new AddressAudit();


            audit.FirstName = address.FirstName;
            audit.LastName = address.LastName;
            audit.AddressLine1 = address.AddressLine1;
            audit.AddressLine2 = address.AddressLine2;
            audit.AddressLine3 = address.AddressLine3;
            audit.City = address.City;
            audit.PostCode = address.PostCode;
            audit.LandLineNumber = address.LandLineNumber;
            audit.MobileNumber = address.MobileNumber;
            audit.County = address.County;
            audit.AddressToBeSent = DateTime.Now;
            audit.Deleted = address.Deleted;

            return audit;
        }
    }
}
