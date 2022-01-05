using Microsoft.EntityFrameworkCore.Migrations;

namespace AddressBook.API.Migrations
{
    public partial class SeedDbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AddressBooks",
                columns: new[] { "AddressBookId", "AddressLine1", "AddressLine2", "AddressLine3", "City", "FirstName", "LandLineNumber", "LastName", "MobileNumber", "PostCode" },
                values: new object[] { 1, "13 Pinnacle Drive", "Egerton", "Bla", "Bolton", "Daniel", "01204123456", "Garsden", "07123456789", "BL7 9XD" });

            migrationBuilder.InsertData(
                table: "AddressBooks",
                columns: new[] { "AddressBookId", "AddressLine1", "AddressLine2", "AddressLine3", "City", "FirstName", "LandLineNumber", "LastName", "MobileNumber", "PostCode" },
                values: new object[] { 2, "13 Pinnacle Drive", "Egerton", "Bla", "Bolton", "Zita", "01204123456", "Garsden", "07123456789", "BL7 9XD" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AddressBooks",
                keyColumn: "AddressBookId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AddressBooks",
                keyColumn: "AddressBookId",
                keyValue: 2);
        }
    }
}
