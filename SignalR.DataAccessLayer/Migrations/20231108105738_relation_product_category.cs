using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.DataAccessLayer.Migrations
{
    public partial class relation_product_category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CatregoryID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CatregoryID",
                table: "Products",
                column: "CatregoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CatregoryID",
                table: "Products",
                column: "CatregoryID",
                principalTable: "Categories",
                principalColumn: "CatregoryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CatregoryID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CatregoryID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CatregoryID",
                table: "Products");
        }
    }
}
