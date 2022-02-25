using System;
using System.Collections.Generic;
using NUnit.Framework;
using Microsoft.Extensions.Logging;
using AddressBook.Worker;
using AddressBook.Data.Entities;

namespace AddressBook.Worker.Tests
{
    public class AddressBookProcessTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAddressAudits_ReturnsEnumAddressAudits()
        {
            // Arrange
            FakeAddressBookAuditRepository fake = new FakeAddressBookAuditRepository();
            using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var logger = loggerFactory.CreateLogger<Worker>();
            ProcessAddressAudits process = new ProcessAddressAudits(fake, logger);

            // Act
            var result = process.Process();

            //Assert
            Assert.IsInstanceOf<IEnumerable<AddressAudit>>(result);

        }

        [Test]
        public void GetAddressAudits_ReturnsProcessedRecords()
        {
            // Arrange
            FakeAddressBookAuditRepository fake = new FakeAddressBookAuditRepository();
            using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var logger = loggerFactory.CreateLogger<Worker>();
            ProcessAddressAudits process = new ProcessAddressAudits(fake, logger);

            // Act
            var result = process.Process();
            IEnumerable<AddressAudit> records = result;

            //Assert
            foreach(AddressAudit record in records)
            {
                Assert.IsNull(record.AddressToBeSent);
                Assert.IsInstanceOf(typeof(DateTime), record.AddressSentAt);
                Assert.IsTrue(DateTime.MinValue < record.AddressSentAt);   
            }
            

        }
    }
}