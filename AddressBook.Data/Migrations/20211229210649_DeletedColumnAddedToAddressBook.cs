using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AddressBook.API.Migrations
{
    public partial class DeletedColumnAddedToAddressBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "AddressBooks",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "AddressBooks");
        }
    }
}
