using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniCRMBlazor.Server.DAL.Migrations
{
    /// <inheritdoc />
    public partial class add_dates_to_contract : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PersonResponsibleName",
                table: "CustomerContacts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sector",
                table: "CustomerContacts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateLastUpdate",
                table: "Contracts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateStart",
                table: "Contracts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonResponsibleName",
                table: "CustomerContacts");

            migrationBuilder.DropColumn(
                name: "Sector",
                table: "CustomerContacts");

            migrationBuilder.DropColumn(
                name: "DateLastUpdate",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "DateStart",
                table: "Contracts");
        }
    }
}
