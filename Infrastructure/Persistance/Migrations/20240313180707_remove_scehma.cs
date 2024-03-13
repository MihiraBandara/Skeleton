using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skeleton.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class remove_scehma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Products",
                schema: "Skeleton",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Orders",
                schema: "Skeleton",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                schema: "Skeleton",
                newName: "OrderItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Skeleton");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Products",
                newSchema: "Skeleton");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Orders",
                newSchema: "Skeleton");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "OrderItems",
                newSchema: "Skeleton");
        }
    }
}
