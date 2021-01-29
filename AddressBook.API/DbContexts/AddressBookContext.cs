using Microsoft.EntityFrameworkCore;
using AddressBook.API.Entities;

namespace AddressBook.API.DbContexts
{
    public class AddressBookContext : DbContext
    {
        public AddressBookContext(DbContextOptions<AddressBookContext> options) : base(options)
        {

        }

        public DbSet<Address> AddressBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasData(
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
                    MobileNumber = "07123456789"
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
                    MobileNumber = "07123456789"
                }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
