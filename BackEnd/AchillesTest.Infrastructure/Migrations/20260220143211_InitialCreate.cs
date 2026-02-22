using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AchillesTest.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CURSO",
                columns: table => new
                {
                    IdCurso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nomb_cur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dura_cur = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CURSO", x => x.IdCurso);
                });

            migrationBuilder.CreateTable(
                name: "TB_PROFESION",
                columns: table => new
                {
                    IdProfesion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nomb_pro = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PROFESION", x => x.IdProfesion);
                });

            migrationBuilder.CreateTable(
                name: "TB_PROVINCIA",
                columns: table => new
                {
                    IdProvincia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nomb_pro = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PROVINCIA", x => x.IdProvincia);
                });

            migrationBuilder.CreateTable(
                name: "TB_DOCENTE",
                columns: table => new
                {
                    IdDocente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apel_doc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nomb_doc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdProfesion = table.Column<int>(type: "int", nullable: false),
                    ProfesionIdProfesion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DOCENTE", x => x.IdDocente);
                    table.ForeignKey(
                        name: "FK_TB_DOCENTE_TB_PROFESION_ProfesionIdProfesion",
                        column: x => x.ProfesionIdProfesion,
                        principalTable: "TB_PROFESION",
                        principalColumn: "IdProfesion");
                });

            migrationBuilder.CreateTable(
                name: "TB_DISTRITO",
                columns: table => new
                {
                    IdDistrito = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nomb_dis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Idprovincia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DISTRITO", x => x.IdDistrito);
                    table.ForeignKey(
                        name: "FK_TB_DISTRITO_TB_PROVINCIA_Idprovincia",
                        column: x => x.Idprovincia,
                        principalTable: "TB_PROVINCIA",
                        principalColumn: "IdProvincia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_ASIGNACION",
                columns: table => new
                {
                    IdAsignacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fect_asi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdDocente = table.Column<int>(type: "int", nullable: false),
                    IdCurso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ASIGNACION", x => x.IdAsignacion);
                    table.ForeignKey(
                        name: "FK_TB_ASIGNACION_TB_CURSO_IdCurso",
                        column: x => x.IdCurso,
                        principalTable: "TB_CURSO",
                        principalColumn: "IdCurso",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_ASIGNACION_TB_DOCENTE_IdDocente",
                        column: x => x.IdDocente,
                        principalTable: "TB_DOCENTE",
                        principalColumn: "IdDocente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_ESTUDIANTE",
                columns: table => new
                {
                    IdEstudiante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apel_est = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nomb_est = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDistrito = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ESTUDIANTE", x => x.IdEstudiante);
                    table.ForeignKey(
                        name: "FK_TB_ESTUDIANTE_TB_DISTRITO_IdDistrito",
                        column: x => x.IdDistrito,
                        principalTable: "TB_DISTRITO",
                        principalColumn: "IdDistrito",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_MATRICULA",
                columns: table => new
                {
                    IdMatricula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fech_mat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstudiante = table.Column<int>(type: "int", nullable: false),
                    IdCurso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MATRICULA", x => x.IdMatricula);
                    table.ForeignKey(
                        name: "FK_TB_MATRICULA_TB_CURSO_IdCurso",
                        column: x => x.IdCurso,
                        principalTable: "TB_CURSO",
                        principalColumn: "IdCurso",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_MATRICULA_TB_ESTUDIANTE_IdEstudiante",
                        column: x => x.IdEstudiante,
                        principalTable: "TB_ESTUDIANTE",
                        principalColumn: "IdEstudiante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ASIGNACION_IdCurso",
                table: "TB_ASIGNACION",
                column: "IdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ASIGNACION_IdDocente",
                table: "TB_ASIGNACION",
                column: "IdDocente");

            migrationBuilder.CreateIndex(
                name: "IX_TB_DISTRITO_Idprovincia",
                table: "TB_DISTRITO",
                column: "Idprovincia");

            migrationBuilder.CreateIndex(
                name: "IX_TB_DOCENTE_ProfesionIdProfesion",
                table: "TB_DOCENTE",
                column: "ProfesionIdProfesion");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ESTUDIANTE_IdDistrito",
                table: "TB_ESTUDIANTE",
                column: "IdDistrito");

            migrationBuilder.CreateIndex(
                name: "IX_TB_MATRICULA_IdCurso",
                table: "TB_MATRICULA",
                column: "IdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_TB_MATRICULA_IdEstudiante",
                table: "TB_MATRICULA",
                column: "IdEstudiante");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ASIGNACION");

            migrationBuilder.DropTable(
                name: "TB_MATRICULA");

            migrationBuilder.DropTable(
                name: "TB_DOCENTE");

            migrationBuilder.DropTable(
                name: "TB_CURSO");

            migrationBuilder.DropTable(
                name: "TB_ESTUDIANTE");

            migrationBuilder.DropTable(
                name: "TB_PROFESION");

            migrationBuilder.DropTable(
                name: "TB_DISTRITO");

            migrationBuilder.DropTable(
                name: "TB_PROVINCIA");
        }
    }
}
