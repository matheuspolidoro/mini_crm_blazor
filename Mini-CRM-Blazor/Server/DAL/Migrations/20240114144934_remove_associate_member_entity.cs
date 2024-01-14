using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniCRMBlazor.Server.DAL.Migrations
{
    /// <inheritdoc />
    public partial class remove_associate_member_entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_AssociateMembers_AssociateMemberId",
                table: "Contracts");

            migrationBuilder.DropTable(
                name: "AssociateMembers");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_AssociateMemberId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "AssociateMemberId",
                table: "Contracts");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Contracts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanySubscriberId",
                table: "AspNetUsers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ApplicationUserId",
                table: "Contracts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanySubscriberId",
                table: "AspNetUsers",
                column: "CompanySubscriberId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_CompanySubscribers_CompanySubscriberId",
                table: "AspNetUsers",
                column: "CompanySubscriberId",
                principalTable: "CompanySubscribers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_AspNetUsers_ApplicationUserId",
                table: "Contracts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_CompanySubscribers_CompanySubscriberId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_AspNetUsers_ApplicationUserId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_ApplicationUserId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CompanySubscriberId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "CompanySubscriberId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "AssociateMemberId",
                table: "Contracts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "AssociateMembers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "text", nullable: false),
                    CompanySubscriberId = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Position = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociateMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssociateMembers_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssociateMembers_CompanySubscribers_CompanySubscriberId",
                        column: x => x.CompanySubscriberId,
                        principalTable: "CompanySubscribers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_AssociateMemberId",
                table: "Contracts",
                column: "AssociateMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_AssociateMembers_ApplicationUserId",
                table: "AssociateMembers",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AssociateMembers_CompanySubscriberId",
                table: "AssociateMembers",
                column: "CompanySubscriberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_AssociateMembers_AssociateMemberId",
                table: "Contracts",
                column: "AssociateMemberId",
                principalTable: "AssociateMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
