using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace restaurant.Data.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_producto_categoriaProductoId",
                table: "producto");

            migrationBuilder.CreateIndex(
                name: "IX_producto_categoriaProductoId",
                table: "producto",
                column: "categoriaProductoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_producto_categoriaProductoId",
                table: "producto");

            migrationBuilder.CreateIndex(
                name: "IX_producto_categoriaProductoId",
                table: "producto",
                column: "categoriaProductoId",
                unique: true);
        }
    }
}
