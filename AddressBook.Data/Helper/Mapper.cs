using System;
using AddressBook.Data.Entities;

namespace AddressBook.Data.Helper
{
    public static class Mapper
    {
        /// <summary>
        /// Create an AddressBookAudit entity from an AddressBook entity
        /// </summary>
        /// <param name="address"></param>
        /// <param name="delete"></param>
        /// <returns></returns>
        public static AddressAudit MapAddressToAddressAudit(Address address)
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
