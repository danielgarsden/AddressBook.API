using AddressBook.API.Controllers;
using AddressBook.API.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
        public void Delete_ValidAddress_ReturnsNoContent()
        {
            // Arrange
            FakeAddressBookRepository fake = new FakeAddressBookRepository();
            AddressController addressController = new AddressController(fake);

            // Act
            var result = addressController.DeleteAddress(2);

            // Assert
            Assert.IsInstanceOf<NoContentResult>(result);
        }

        [Test]
        public void Delete_InValidAddress_ReturnsNotFound()
        {
            // Arrange
            FakeAddressBookRepository fake = new FakeAddressBookRepository();
            AddressController addressController = new AddressController(fake);

            // Act
            var result = addressController.DeleteAddress(12);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void Delete_ValidAddress_DeletesCorrectAddress()
        {
            // Arrange
            FakeAddressBookRepository fake = new FakeAddressBookRepository();
            AddressController addressController = new AddressController(fake);

            // Act
            //var deleteResult = addressController.DeleteAddress(2);
            var getResult = addressController.GetAddresses().Result as OkObjectResult;
            List<AddressDto> addresses = getResult.Value as List<AddressDto>;

            // Assert
            Assert.AreEqual(9, addresses.Count);
        }

        [Test]
        public void CreateAddress_ValidAddress_ReturnsCreatedAtRouteResult()
        {
            // Arrange
            FakeAddressBookRepository fake = new FakeAddressBookRepository();
            AddressController addressController = new AddressController(fake);

            AddressForCreationDto address = new AddressForCreationDto
            {
                FirstName = "Hammett",
                LastName = "Carter",
                AddressLine1 = "721-3599 Cum St.",
                AddressLine2 = "P.O. Box 384, 3935 Bibendum Av.",
                AddressLine3 = "Ap #693-4430 Orci. Ave",
                City = "Siheung",
                PostCode = "10023",
                LandLineNumber = "0169777047",
                MobileNumber = "09057895305"
            };

            // Act
            SimulateValidation(address, addressController);
            var result = addressController.CreateAddress(address);

            // Assert
            Assert.IsInstanceOf<CreatedAtRouteResult>(result);
        }

        [Test]
        public void CreateAddress_InValidAddress_ReturnsBadRequestResult()
        {
            // Arrange
            FakeAddressBookRepository fake = new FakeAddressBookRepository();
            AddressController addressController = new AddressController(fake);

            // required fields are FirstName, LastName, 
            AddressForCreationDto address = new AddressForCreationDto
            {
                FirstName = "Hammett",
            };

            // Act
            SimulateValidation(address, addressController);
            var result = addressController.CreateAddress(address);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        private static void SimulateValidation(object address, AddressController controller)
        {
            // mimic the behaviour of the model binder which is responsible for Validating the Model
            var validationContext = new ValidationContext(address, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(address, validationContext, validationResults, true);
            foreach (var validationResult in validationResults)
            {
                controller.ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);
            }
        }
    }
}
