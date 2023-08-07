using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DenemeAPI.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cat",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "pageNo",
                table: "Books",
                newName: "PageNo");

            migrationBuilder.RenameColumn(
                name: "cost",
                table: "Books",
                newName: "Cost");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "cat");

            migrationBuilder.RenameColumn(
                name: "PageNo",
                table: "Books",
                newName: "pageNo");

            migrationBuilder.RenameColumn(
                name: "Cost",
                table: "Books",
                newName: "cost");
        }
    }
}
