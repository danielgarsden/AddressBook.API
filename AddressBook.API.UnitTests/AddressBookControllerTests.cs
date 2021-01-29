using NUnit.Framework;
using AddressBook.API.Controllers;
using AddressBook.API.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.API.UnitTests
{
    public class AddressBookControllerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAddresses_ReturnsOkResult()
        {
            // Arrange
            FakeAddressBookRepository fake = new FakeAddressBookRepository();
            AddressController addressController = new AddressController(fake);

            // Act
            var result = addressController.GetAddresses();

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);

        }

        [Test]
        public void GetAddresses_ReturnsAddressDtoList()
        {
            // Arrange
            FakeAddressBookRepository fake = new FakeAddressBookRepository();
            AddressController addressController = new AddressController(fake);

            // Act
            var result = addressController.GetAddresses().Result as OkObjectResult;

            // Assert
            Assert.IsInstanceOf<List<AddressDto>>(result.Value);

        }

        [Test]
        public void GetAddresses_ReturnsAllItems()
        {
            // Arrange
            FakeAddressBookRepository fake = new FakeAddressBookRepository();
            AddressController addressController = new AddressController(fake);

            // Act
            var result = addressController.GetAddresses().Result as OkObjectResult;
            List<AddressDto> addresses = result.Value as List<AddressDto>;

            // Assert
            Assert.AreEqual(10, addresses.Count);
        }

        [Test]
        public void GetAddress_ValidAddress_ReturnsOkResult()
        {
            // Arrange
            FakeAddressBookRepository fake = new FakeAddressBookRepository();
            AddressController addressController = new AddressController(fake);

            // Act
            var result = addressController.GetAddress(1);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public void GetAddress_InValidAddress_ReturnsNotFoundResult()
        {
            // Arrange
            FakeAddressBookRepository fake = new FakeAddressBookRepository();
            AddressController addressController = new AddressController(fake);

            // Act
            var result = addressController.GetAddress(11);

            //Assert
            Assert.IsInstanceOf<NotFoundResult>(result.Result);
        }

        [Test]
        public void GetAddress_ReturnsCorrectAddress()
        {
            // Arrange
            FakeAddressBookRepository fake = new FakeAddressBookRepository();
            AddressController addressController = new AddressController(fake);

            // Act
            var result = addressController.GetAddress(7).Result as OkObjectResult;
            AddressDto address = result.Value as AddressDto;

            //Assert
            Assert.AreEqual(7, address.AddressId);
            Assert.AreEqual("Henry", address.FirstName);
            Assert.AreEqual("Pickett", address.LastName);
            Assert.AreEqual("P.O. Box 838, 3021 Bibendum Rd.", address.AddressLine1);
            Assert.AreEqual("608-7007 Arcu. Ave", address.AddressLine2);
            Assert.AreEqual("Ap #393-2002 In Ave", address.AddressLine3);
            Assert.AreEqual("Villenave-d'Ornon", address.City);
            Assert.AreEqual("31207", address.PostCode);
            Assert.AreEqual("01052892190", address.LandLineNumber);
            Assert.AreEqual("05542645886", address.MobileNumber);
        }

        [Test]
        public void Delete_SubjectReturnsNoContent()
        {
            // Arrange
            FakeAddressBookRepository fake = new FakeAddressBookRepository();
            AddressController addressController = new AddressController(fake);

            // Act
            var result = addressController.DeleteAddress(2);

            // Assert
            Assert.IsInstanceOf<NoContentResult>(result);
        }


    }
}
