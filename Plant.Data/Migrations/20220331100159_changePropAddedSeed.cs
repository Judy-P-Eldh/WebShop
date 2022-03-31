using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plant.Data.Migrations
{
    public partial class changePropAddedSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Offer");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Offer",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Event",
                newName: "Title");

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Offer",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Event",
                newName: "Name");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Offer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "PostalCode",
                table: "Address",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
