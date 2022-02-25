using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AddressBook.API.Migrations
{
    public partial class AuditDateTimesNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "AddressToBeSent",
                table: "AddressBooksAudit",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddressSentAt",
                table: "AddressBooksAudit",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AddressBooks",
                keyColumn: "AddressId",
                keyValue: 1,
                column: "County",
                value: "Lancashire");

            migrationBuilder.UpdateData(
                table: "AddressBooks",
                keyColumn: "AddressId",
                keyValue: 2,
                column: "County",
                value: "Lancashire");

            migrationBuilder.InsertData(
                table: "AddressBooksAudit",
                columns: new[] { "AddressAuditId", "AddressId", "AddressLine1", "AddressLine2", "AddressLine3", "AddressSentAt", "AddressToBeSent", "City", "County", "Deleted", "FirstName", "LandLineNumber", "LastName", "MobileNumber", "PostCode" },
                values: new object[,]
                {
                    { 1, 1, "13 Pinnacle Drive", "Egerton", "Bla", null, null, "Bolton", "Lancashire", false, "Daniel", "01204123456", "Garsden", "07123456789", "BL7 9XD" },
                    { 2, 2, "13 Pinnacle Drive", "Egerton", "Bla", null, null, "Bolton", "Lancashire", false, "Zita", "01204123456", "Garsden", "07123456789", "BL7 9XD" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AddressBooksAudit",
                keyColumn: "AddressAuditId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AddressBooksAudit",
                keyColumn: "AddressAuditId",
                keyValue: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddressToBeSent",
                table: "AddressBooksAudit",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddressSentAt",
                table: "AddressBooksAudit",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AddressBooks",
                keyColumn: "AddressId",
                keyValue: 1,
                column: "County",
                value: null);

            migrationBuilder.UpdateData(
                table: "AddressBooks",
                keyColumn: "AddressId",
                keyValue: 2,
                column: "County",
                value: null);
        }
    }
}
