using AddressBook.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Data.DbContexts
{
    public class AddressBookContext : DbContext
    {
        public AddressBookContext(DbContextOptions<AddressBookContext> options) : base(options)
        {

        }

        public DbSet<Address> AddressBooks { get; set; }

        public DbSet<AddressAudit> AddressBooksAudit { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasMany(a => a.AddressAudit)
                .WithOne(a => a.Address);

            modelBuilder.Entity<Address>()
                .HasData(
                new Address()
                {
                    AddressId = 1,
                    FirstName = "Daniel",
                    LastName = "Garsden",
                    AddressLine1 = "13 Pinnacle Drive",
                    AddressLine2 = "Egerton",
                    AddressLine3 = "Bla",
                    City = "Bolton",
                    PostCode = "BL7 9XD",
                    LandLineNumber = "01204123456",
                    MobileNumber = "07123456789",
                    County = "Lancashire"
                },
                new Address()
                {
                    AddressId = 2,
                    FirstName = "Zita",
                    LastName = "Garsden",
                    AddressLine1 = "13 Pinnacle Drive",
                    AddressLine2 = "Egerton",
                    AddressLine3 = "Bla",
                    City = "Bolton",
                    PostCode = "BL7 9XD",
                    LandLineNumber = "01204123456",
                    MobileNumber = "07123456789",
                    County = "Lancashire"
                }
                );

            modelBuilder.Entity<AddressAudit>()
                .HasData(
                new AddressAudit()
                {
                    AddressAuditId = 1,
                    AddressId = 1,
                    FirstName = "Daniel",
                    LastName = "Garsden",
                    AddressLine1 = "13 Pinnacle Drive",
                    AddressLine2 = "Egerton",
                    AddressLine3 = "Bla",
                    City = "Bolton",
                    PostCode = "BL7 9XD",
                    LandLineNumber = "01204123456",
                    MobileNumber = "07123456789",
                    County = "Lancashire"
                },
                new AddressAudit()
                {
                    AddressAuditId = 2,
                    AddressId = 2,
                    FirstName = "Zita",
                    LastName = "Garsden",
                    AddressLine1 = "13 Pinnacle Drive",
                    AddressLine2 = "Egerton",
                    AddressLine3 = "Bla",
                    City = "Bolton",
                    PostCode = "BL7 9XD",
                    LandLineNumber = "01204123456",
                    MobileNumber = "07123456789",
                    County = "Lancashire"
                }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
