using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AddressBook.API.Migrations
{
    public partial class DeleteColumnChangedInAudit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddressToBeDeleted",
                table: "AddressBooksAudit",
                newName: "Deleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "AddressBooksAudit",
                newName: "AddressToBeDeleted");
        }
    }
}
