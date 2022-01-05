using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AddressBook.API.Migrations
{
    public partial class AddedAudit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressBooksAudit",
                columns: table => new
                {
                    AddressAuditId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddressLine3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LandLineNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    County = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AddressToBeSent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddressToBeDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AddressSentAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressBooksAudit", x => x.AddressAuditId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressBooksAudit");
        }
    }
}
