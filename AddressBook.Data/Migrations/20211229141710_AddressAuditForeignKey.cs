using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AddressBook.API.Migrations
{
    public partial class AddressAuditForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AddressBooksAudit_AddressId",
                table: "AddressBooksAudit",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressBooksAudit_AddressBooks_AddressId",
                table: "AddressBooksAudit",
                column: "AddressId",
                principalTable: "AddressBooks",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressBooksAudit_AddressBooks_AddressId",
                table: "AddressBooksAudit");

            migrationBuilder.DropIndex(
                name: "IX_AddressBooksAudit_AddressId",
                table: "AddressBooksAudit");
        }
    }
}
