using System.Collections.Generic;
using AddressBook.API.Entities;

namespace AddressBook.API.Services
{
    /// <summary>
    /// Interface for AddressBook Repository
    /// </summary>
    public interface IAddressBookRepository
    {
        /// <summary>
        /// Get All Address Book Entries
        /// </summary>
        /// <returns>IEnumerable of the AddressBook Entity</returns>
        IEnumerable<Address> GetAddresses();

        /// <summary>
        /// Get one AddressBook Entry by the AddressBookId
        /// </summary>
        /// <param name="addressBookId"></param>
        /// <returns>An AddressBook Entry</returns>
        Address GetAddress(int addressBookId);

        /// <summary>
        /// Add an AddressBook Entry
        /// </summary>
        /// <param name="addressBook"></param>
        void AddAddress(Address addressBook);

        /// <summary>
        /// Add an AddressBook Entry
        /// </summary>
        /// <param name="addressBook"></param>
        void DeleteAddress(Address addressBook);

        /// <summary>
        /// Update an AddressBook Entry
        /// </summary>
        /// <param name="addressBook"></param>
        void UpdateAddress(Address addressBook);

        /// <summary>
        /// Check that an AddressBook Entry exists
        /// </summary>
        /// <param name="addressBookId"></param>
        /// <returns>bool as to whether the address already exists</returns>
        bool AddressExists(int addressBookId);

        /// <summary>
        /// Save the changes
        /// </summary>
        /// <returns>bool as the whether the save was sucessful or not</returns>
        bool Save();


    }
}
