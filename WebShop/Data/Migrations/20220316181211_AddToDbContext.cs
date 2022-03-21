using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShop.Data.Migrations
{
    public partial class AddToDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_PlantCategory_PlantCategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_PlantSize_PlantSizeId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlantSize",
                table: "PlantSize");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlantCategory",
                table: "PlantCategory");

            migrationBuilder.RenameTable(
                name: "PlantSize",
                newName: "PlantSizes");

            migrationBuilder.RenameTable(
                name: "PlantCategory",
                newName: "Category");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlantSizes",
                table: "PlantSizes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Category_PlantCategoryId",
                table: "Products",
                column: "PlantCategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_PlantSizes_PlantSizeId",
                table: "Products",
                column: "PlantSizeId",
                principalTable: "PlantSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Category_PlantCategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_PlantSizes_PlantSizeId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlantSizes",
                table: "PlantSizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "PlantSizes",
                newName: "PlantSize");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "PlantCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlantSize",
                table: "PlantSize",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlantCategory",
                table: "PlantCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_PlantCategory_PlantCategoryId",
                table: "Products",
                column: "PlantCategoryId",
                principalTable: "PlantCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_PlantSize_PlantSizeId",
                table: "Products",
                column: "PlantSizeId",
                principalTable: "PlantSize",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
