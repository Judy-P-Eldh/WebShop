using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShop.Data.Migrations
{
    public partial class AddedClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_PlantType_PlantTypeId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "PlantType");

            migrationBuilder.RenameColumn(
                name: "PlantTypeId",
                table: "Products",
                newName: "PlantSizeId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_PlantTypeId",
                table: "Products",
                newName: "IX_Products_PlantSizeId");

            migrationBuilder.AddColumn<int>(
                name: "PlantCategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PlantCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlantSize",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantSize", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_PlantCategoryId",
                table: "Products",
                column: "PlantCategoryId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_PlantCategory_PlantCategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_PlantSize_PlantSizeId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "PlantCategory");

            migrationBuilder.DropTable(
                name: "PlantSize");

            migrationBuilder.DropIndex(
                name: "IX_Products_PlantCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PlantCategoryId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "PlantSizeId",
                table: "Products",
                newName: "PlantTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_PlantSizeId",
                table: "Products",
                newName: "IX_Products_PlantTypeId");

            migrationBuilder.CreateTable(
                name: "PlantType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantType", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_PlantType_PlantTypeId",
                table: "Products",
                column: "PlantTypeId",
                principalTable: "PlantType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
