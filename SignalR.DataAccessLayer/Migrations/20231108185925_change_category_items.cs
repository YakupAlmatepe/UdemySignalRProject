using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.DataAccessLayer.Migrations
{
    public partial class change_category_items : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CatregoryName",
                table: "Categories",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "CatregoryID",
                table: "Categories",
                newName: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Categories",
                newName: "CatregoryName");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Categories",
                newName: "CatregoryID");
        }
    }
}
