using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace restaurant.Data.Migrations
{
    /// <inheritdoc />
    public partial class FourthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id_categoria",
                table: "usuario",
                newName: "id_usuario");

            migrationBuilder.AddColumn<string>(
                name: "usuario_rol",
                table: "usuario",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "usuario_rol",
                table: "usuario");

            migrationBuilder.RenameColumn(
                name: "id_usuario",
                table: "usuario",
                newName: "id_categoria");
        }
    }
}
