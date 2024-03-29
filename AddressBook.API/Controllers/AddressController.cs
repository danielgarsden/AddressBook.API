﻿using AddressBook.Data.Entities;
using AddressBook.Shared.Models;
using AddressBook.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AddressBook.API.Controllers
{
    /// <summary>
    /// Controller for the Address Entity
    /// </summary>
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/addresses")]
    [Produces("application/json")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressBookRepository _addressBookRepository;

        private readonly ILogger<AddressController> _logger;

        public AddressController(IAddressBookRepository addressBookRepository, ILogger<AddressController> logger)
        {
            _addressBookRepository = addressBookRepository ?? throw new ArgumentNullException(nameof(addressBookRepository));
            _logger = logger;
        }

        /// <summary>
        /// Get All Subjects
        /// </summary>
        /// <returns>List of AddressDto</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet()]
        public ActionResult<IEnumerable<AddressDto>> GetAddresses()
        {
            _logger.LogInformation("Entered Get Addresses Method.");

            // get addresses from repository
            IEnumerable<Address> addressesFromRepo = _addressBookRepository.GetAddresses();

            _logger.LogInformation("Retrieved Addresses from the database.");

            // Create a dto to be used to return data
            List<AddressDto> addressesToReturn = new List<AddressDto>();

            // Loop through address from repoository and add to the return dto
            foreach (Address address in addressesFromRepo)
            {
                addressesToReturn.Add(new AddressDto
                {
                    AddressId = address.AddressId,
                    FirstName = address.FirstName,
                    LastName = address.LastName,
                    AddressLine1 = address.AddressLine1,
                    AddressLine2 = address.AddressLine2,
                    AddressLine3 = address.AddressLine3,
                    City = address.City,
                    PostCode = address.PostCode,
                    LandLineNumber = address.LandLineNumber,
                    MobileNumber = address.MobileNumber
                });
            }

            _logger.LogInformation("Addresses retrieved are {@addressesToReturn}.", addressesToReturn);

            // return OK status code and dto
            return Ok(addressesToReturn);
        }

        /// <summary>
        /// Get All Subjects
        /// </summary>
        /// <returns>List of AddressDto</returns>
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[HttpGet()]
        //public ActionResult<IEnumerable<AddressDto>> GetAddressesV2()
        //{
        //    // get addresses from repository
        //    IEnumerable<Address> addressesFromRepo = _addressBookRepository.GetAddresses();

        //    // Create a dto to be used to return data
        //    List<AddressDto> addressesToReturn = new List<AddressDto>();

        //    // Loop through address from repoository and add to the return dto
        //    foreach (Address address in addressesFromRepo)
        //    {
        //        addressesToReturn.Add(new AddressDto
        //        {
        //            AddressId = address.AddressId,
        //            FirstName = address.FirstName,
        //            LastName = address.LastName,
        //            AddressLine1 = address.AddressLine1,
        //            AddressLine2 = address.AddressLine2,
        //            AddressLine3 = address.AddressLine3,
        //            City = address.City,
        //            PostCode = address.PostCode,
        //            LandLineNumber = address.LandLineNumber,
        //            MobileNumber = address.MobileNumber
        //        });
        //    }

        //    // return OK status code and dto
        //    return Ok(addressesToReturn);
        //}

        /// <summary>
        /// Get an address
        /// </summary>
        /// <param name="addressId">The Id of the address to return</param>
        /// <returns>AddressDto</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{addressId}", Name = "GetAddress")]
        public ActionResult<AddressDto> GetAddress(int addressId)
        {
            _logger.LogInformation("Entered Get Address Method. With an address ID of " + addressId.ToString());

            // get the specific address from repository
            Address addressesFromRepo = _addressBookRepository.GetAddress(addressId);

            _logger.LogInformation("Retrieved Address from the database.");

            // if no matching addresses are found then return NotFound status code
            if (addressesFromRepo == null)
            {
                return NotFound();
            }

            // map address from repository to the dto
            AddressDto addressToReturn = new AddressDto
            {
                AddressId = addressesFromRepo.AddressId,
                FirstName = addressesFromRepo.FirstName,
                LastName = addressesFromRepo.LastName,
                AddressLine1 = addressesFromRepo.AddressLine1,
                AddressLine2 = addressesFromRepo.AddressLine2,
                AddressLine3 = addressesFromRepo.AddressLine3,
                City = addressesFromRepo.City,
                PostCode = addressesFromRepo.PostCode,
                LandLineNumber = addressesFromRepo.LandLineNumber,
                MobileNumber = addressesFromRepo.MobileNumber
            };

            _logger.LogInformation("Address retrieved are {@addressToReturn}.", addressToReturn);

            // return OK status code and dto
            return Ok(addressToReturn);
        }

        /// <summary>
        /// Creates an Address
        /// </summary>
        /// <param name="address">The address to create</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Consumes("application/json")]
        [HttpPost]
        public ActionResult CreateAddress([FromBody] AddressForCreationDto address)
        {
            _logger.LogInformation("Entered Create Address Method.");

            _logger.LogInformation("Model state is {@ModelState}.", ModelState);

            // check that dto we have been passed is valid, if not return bad request status code
            // and the associated validation faults
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("Bad Model State.");
                return BadRequest(ModelState);
            }

            // map dto to and address entity
            Address addressToCreate = new Address
            {
                FirstName = address.FirstName,
                LastName = address.LastName,
                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                AddressLine3 = address.AddressLine3,
                City = address.City,
                PostCode = address.PostCode,
                LandLineNumber = address.LandLineNumber,
                MobileNumber = address.MobileNumber
            };

            _logger.LogInformation("About to save address to DB {@addresToCreate}", addressToCreate);

            // add address to repository and save
            _addressBookRepository.AddAddress(addressToCreate);
            _addressBookRepository.Save();

            _logger.LogInformation("Address saved to DB.");

            // map the created entity to a dto to be returned
            AddressDto addressToReturn = new AddressDto
            {
                AddressId = addressToCreate.AddressId,
                FirstName = addressToCreate.FirstName,
                LastName = addressToCreate.LastName,
                AddressLine1 = addressToCreate.AddressLine1,
                AddressLine2 = addressToCreate.AddressLine2,
                AddressLine3 = addressToCreate.AddressLine3,
                City = addressToCreate.City,
                PostCode = addressToCreate.PostCode,
                LandLineNumber = addressToCreate.LandLineNumber,
                MobileNumber = addressToCreate.MobileNumber
            };

            _logger.LogInformation("Address saved to DB {@addressToReturn}", addressToReturn);

            // return created status code and the details of what was created
            return CreatedAtRoute("GetAddress", new { addressToReturn.AddressId }, addressToReturn);
        }

        /// <summary>
        /// Delete an address
        /// </summary>
        /// <param name="addressId">The Id of the address to delete</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{addressId}")]
        public ActionResult DeleteAddress(int addressId)
        {
            _logger.LogInformation("Entered Delete Address Method.  With an address ID of " + addressId.ToString());

            // get the specific address from repository
            Address addressFromRepo = _addressBookRepository.GetAddress(addressId);

            _logger.LogInformation("Retrieved Address from the database.");

            // if no matching addresses are found then return NotFound status code
            if (addressFromRepo == null)
            {
                _logger.LogInformation("No matching address was found.");
                return NotFound();
            }

            _logger.LogInformation("About to save address to DB {@addressFromRepo}", addressFromRepo);

            // delete address from repository and save
            _addressBookRepository.DeleteAddress(addressFromRepo);
            _addressBookRepository.Save();

            _logger.LogInformation("Address Deleted.");

            // return success status code of type NoContent
            return NoContent();
        }

        /// <summary>
        /// Update an address
        /// </summary>
        /// <param name="addressId">The Id of the address to update</param>
        /// <param name="address">The dto with the new address details</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Consumes("application/json")]
        [HttpPut("{addressId}")]
        public ActionResult UpdateAddress(int addressId, AddressDto address)
        {
            _logger.LogInformation("Entered Update Address Method.");

            _logger.LogInformation("Model state is {@ModelState}.", ModelState);

            // check that dto we have been passed is valid, if not return bad request status code
            // and the associated validation faults
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("Bad request.");
                return BadRequest(ModelState);
            }

            // get the specific address from repository
            Address addressFromRepo = _addressBookRepository.GetAddress(addressId);

            // if no matching addresses are found then return NotFound status code
            if (addressFromRepo == null)
            {
                _logger.LogInformation("Address To Update Not Found.");
                return NotFound();
            }

            // update the entity receive from repository
            addressFromRepo.FirstName = address.FirstName;
            addressFromRepo.LastName = address.LastName;
            addressFromRepo.AddressLine1 = address.AddressLine1;
            addressFromRepo.AddressLine2 = address.AddressLine2;
            addressFromRepo.AddressLine3 = address.AddressLine3;
            addressFromRepo.City = address.City;
            addressFromRepo.PostCode = address.PostCode;
            addressFromRepo.LandLineNumber = address.LandLineNumber;
            addressFromRepo.MobileNumber = address.MobileNumber;

            _logger.LogInformation("About to save address to DB {@addressFromRepo}", addressFromRepo);

            // update address in repository and save
            _addressBookRepository.UpdateAddress(addressFromRepo);
            _addressBookRepository.Save();

            _logger.LogInformation("Address Updated.");

            // return success status code of type NoContent
            return NoContent();
        }
    }
}
