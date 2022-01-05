using Microsoft.EntityFrameworkCore.Migrations;

namespace AddressBook.API.Migrations
{
    public partial class AddedCountyField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddressBookId",
                table: "AddressBooks",
                newName: "AddressId");

            migrationBuilder.AddColumn<string>(
                name: "County",
                table: "AddressBooks",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "County",
                table: "AddressBooks");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "AddressBooks",
                newName: "AddressBookId");
        }
    }
}
