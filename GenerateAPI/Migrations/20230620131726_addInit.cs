using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenerateAPI.Migrations
{
    /// <inheritdoc />
    public partial class addInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Card",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastCreatedBy",
                table: "Card",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastCreatedDateTime",
                table: "Card",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Card",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "LastCreatedBy",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "LastCreatedDateTime",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Card");
        }
    }
}
