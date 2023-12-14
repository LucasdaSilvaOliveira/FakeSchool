using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FakeSchool.Infra.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelaCursos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Turma",
                table: "Alunos");

            migrationBuilder.AddColumn<int>(
                name: "CursoId",
                table: "Alunos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DuracaoAnos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_CursoId",
                table: "Alunos",
                column: "CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Curso_CursoId",
                table: "Alunos",
                column: "CursoId",
                principalTable: "Curso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Curso_CursoId",
                table: "Alunos");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_CursoId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "Alunos");

            migrationBuilder.AddColumn<string>(
                name: "Turma",
                table: "Alunos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
