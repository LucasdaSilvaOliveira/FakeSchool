using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FakeSchool.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoTipoNota : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "NotaMateria",
                table: "Notas",
                type: "decimal(3,1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NotaMateria",
                table: "Notas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
