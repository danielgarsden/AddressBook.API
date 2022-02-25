using AddressBook.Data.Entities;
using System.Collections.Generic;

namespace AddressBook.Data.Services
{
    /// <summary>
    /// Interface for AddressBook Repository
    /// </summary>
    public interface IAddressBookRepository
    {
        /// <summary>
        /// Get All Addresses
        /// </summary>
        /// <returns>IEnumerable of the Address Entity</returns>
        IEnumerable<Address> GetAddresses();

        /// <summary>
        /// Get one Address Entry by the Address Id
        /// </summary>
        /// <param name="addressId"></param>
        /// <returns>An Address Entry</returns>
        Address GetAddress(int addressId);

        /// <summary>
        /// Add an Address Entry
        /// </summary>
        /// <param name="address"></param>
        void AddAddress(Address address);

        /// <summary>
        /// Add an Address Entry
        /// </summary>
        /// <param name="address"></param>
        void DeleteAddress(Address address);

        /// <summary>
        /// Update an Address Entry
        /// </summary>
        /// <param name="address"></param>
        void UpdateAddress(Address address);

        /// <summary>
        /// Check that an Address Entry exists
        /// </summary>
        /// <param name="addressId"></param>
        /// <returns>bool as to whether the address already exists</returns>
        bool AddressExists(int addressId);

        /// <summary>
        /// Save the changes
        /// </summary>
        /// <returns>bool as the whether the save was sucessful or not</returns>
        bool Save();


    }
}
