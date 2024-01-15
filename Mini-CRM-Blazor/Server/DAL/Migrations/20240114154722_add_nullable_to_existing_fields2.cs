using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniCRMBlazor.Server.DAL.Migrations
{
    /// <inheritdoc />
    public partial class add_nullable_to_existing_fields2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_CompanySubscribers_CompanySubscriberId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "CompanySubscriberId",
                table: "AspNetUsers",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_CompanySubscribers_CompanySubscriberId",
                table: "AspNetUsers",
                column: "CompanySubscriberId",
                principalTable: "CompanySubscribers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_CompanySubscribers_CompanySubscriberId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "CompanySubscriberId",
                table: "AspNetUsers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_CompanySubscribers_CompanySubscriberId",
                table: "AspNetUsers",
                column: "CompanySubscriberId",
                principalTable: "CompanySubscribers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
