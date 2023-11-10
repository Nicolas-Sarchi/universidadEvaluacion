using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Curso_Escolar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AnhoInicio = table.Column<short>(type: "YEAR(4)", nullable: false),
                    AnhoFin = table.Column<short>(type: "YEAR(4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso_Escolar", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Grado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grado", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sexo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tipo_Asignatura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Asignatura", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tipo_Persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Persona", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NIF = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido1 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido2 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ciudad = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaNacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    Id_Sexo = table.Column<int>(type: "int", nullable: false),
                    IdTipoPersona = table.Column<int>(type: "int", nullable: false),
                    IdProfesor = table.Column<int>(type: "int", nullable: false),
                    CursoEscolarId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persona_Curso_Escolar_CursoEscolarId",
                        column: x => x.CursoEscolarId,
                        principalTable: "Curso_Escolar",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Persona_Sexo_Id_Sexo",
                        column: x => x.Id_Sexo,
                        principalTable: "Sexo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Persona_Tipo_Persona_IdTipoPersona",
                        column: x => x.IdTipoPersona,
                        principalTable: "Tipo_Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Profesor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    IdPersona = table.Column<int>(type: "int", nullable: false),
                    Id_departamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profesor_Departamento_Id_departamento",
                        column: x => x.Id_departamento,
                        principalTable: "Departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Profesor_Persona_Id",
                        column: x => x.Id,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Asignatura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Creditos = table.Column<float>(type: "float", nullable: false),
                    IdTipoAsignatura = table.Column<int>(type: "int", nullable: false),
                    TipoAsignaturaId = table.Column<int>(type: "int", nullable: true),
                    Curso = table.Column<sbyte>(type: "tinyint(3)", nullable: false),
                    Cuatrimestre = table.Column<sbyte>(type: "tinyint(3)", nullable: false),
                    Id_Grado = table.Column<int>(type: "int", nullable: false),
                    Id_Profesor = table.Column<int>(type: "int", nullable: false),
                    CursoEscolarId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignatura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asignatura_Curso_Escolar_CursoEscolarId",
                        column: x => x.CursoEscolarId,
                        principalTable: "Curso_Escolar",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Asignatura_Grado_Id_Grado",
                        column: x => x.Id_Grado,
                        principalTable: "Grado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asignatura_Profesor_Id_Profesor",
                        column: x => x.Id_Profesor,
                        principalTable: "Profesor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asignatura_Tipo_Asignatura_TipoAsignaturaId",
                        column: x => x.TipoAsignaturaId,
                        principalTable: "Tipo_Asignatura",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Alumno_se_matricula_Asignatura",
                columns: table => new
                {
                    Id_alumno = table.Column<int>(type: "int", nullable: false),
                    Id_asignatura = table.Column<int>(type: "int", nullable: false),
                    Id_curso_escolar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumno_se_matricula_Asignatura", x => new { x.Id_alumno, x.Id_curso_escolar, x.Id_asignatura });
                    table.ForeignKey(
                        name: "FK_Alumno_se_matricula_Asignatura_Asignatura_Id_asignatura",
                        column: x => x.Id_asignatura,
                        principalTable: "Asignatura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alumno_se_matricula_Asignatura_Curso_Escolar_Id_curso_escolar",
                        column: x => x.Id_curso_escolar,
                        principalTable: "Curso_Escolar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alumno_se_matricula_Asignatura_Persona_Id_alumno",
                        column: x => x.Id_alumno,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AsignaturaPersona",
                columns: table => new
                {
                    AsignaturasId = table.Column<int>(type: "int", nullable: false),
                    PersonasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsignaturaPersona", x => new { x.AsignaturasId, x.PersonasId });
                    table.ForeignKey(
                        name: "FK_AsignaturaPersona_Asignatura_AsignaturasId",
                        column: x => x.AsignaturasId,
                        principalTable: "Asignatura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AsignaturaPersona_Persona_PersonasId",
                        column: x => x.PersonasId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_se_matricula_Asignatura_Id_asignatura",
                table: "Alumno_se_matricula_Asignatura",
                column: "Id_asignatura");

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_se_matricula_Asignatura_Id_curso_escolar",
                table: "Alumno_se_matricula_Asignatura",
                column: "Id_curso_escolar");

            migrationBuilder.CreateIndex(
                name: "IX_Asignatura_CursoEscolarId",
                table: "Asignatura",
                column: "CursoEscolarId");

            migrationBuilder.CreateIndex(
                name: "IX_Asignatura_Id_Grado",
                table: "Asignatura",
                column: "Id_Grado");

            migrationBuilder.CreateIndex(
                name: "IX_Asignatura_Id_Profesor",
                table: "Asignatura",
                column: "Id_Profesor");

            migrationBuilder.CreateIndex(
                name: "IX_Asignatura_TipoAsignaturaId",
                table: "Asignatura",
                column: "TipoAsignaturaId");

            migrationBuilder.CreateIndex(
                name: "IX_AsignaturaPersona_PersonasId",
                table: "AsignaturaPersona",
                column: "PersonasId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_CursoEscolarId",
                table: "Persona",
                column: "CursoEscolarId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_Id_Sexo",
                table: "Persona",
                column: "Id_Sexo");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_IdTipoPersona",
                table: "Persona",
                column: "IdTipoPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_Id_departamento",
                table: "Profesor",
                column: "Id_departamento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alumno_se_matricula_Asignatura");

            migrationBuilder.DropTable(
                name: "AsignaturaPersona");

            migrationBuilder.DropTable(
                name: "Asignatura");

            migrationBuilder.DropTable(
                name: "Grado");

            migrationBuilder.DropTable(
                name: "Profesor");

            migrationBuilder.DropTable(
                name: "Tipo_Asignatura");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Curso_Escolar");

            migrationBuilder.DropTable(
                name: "Sexo");

            migrationBuilder.DropTable(
                name: "Tipo_Persona");
        }
    }
}
