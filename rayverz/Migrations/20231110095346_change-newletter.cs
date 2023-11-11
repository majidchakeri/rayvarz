using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rayverz.Migrations
{
    /// <inheritdoc />
    public partial class changenewletter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Newsletters_AspNetUsers_UserId",
                table: "Newsletters");

            migrationBuilder.DropIndex(
                name: "IX_Newsletters_UserId",
                table: "Newsletters");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Newsletters");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Datetime",
                table: "Newsletters",
                newName: "Description");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Newsletters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Newsletters");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Newsletters",
                newName: "Datetime");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Newsletters",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Newsletters_UserId",
                table: "Newsletters",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Newsletters_AspNetUsers_UserId",
                table: "Newsletters",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
