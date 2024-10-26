using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_UBAM.Migrations
{
    /// <inheritdoc />
    public partial class Create_Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carreras",
                columns: table => new
                {
                    Id_Carrera = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre_Carrera = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carreras", x => x.Id_Carrera);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id_Persona = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre_Persona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido_Paterno_Persona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido_Materno_Persona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha_Nacimiento_Persona = table.Column<DateOnly>(type: "date", nullable: false),
                    Sexo_Persona = table.Column<int>(type: "int", nullable: false),
                    Curp_Persona = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id_Persona);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id_Rol = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre_Rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id_Rol);
                });

            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    Id_Alumno = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Grupo_Alumno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_Persona = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Carrera = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.Id_Alumno);
                    table.ForeignKey(
                        name: "FK_Alumnos_Carreras_Id_Carrera",
                        column: x => x.Id_Carrera,
                        principalTable: "Carreras",
                        principalColumn: "Id_Carrera",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alumnos_Personas_Id_Persona",
                        column: x => x.Id_Persona,
                        principalTable: "Personas",
                        principalColumn: "Id_Persona",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Docentes",
                columns: table => new
                {
                    Id_Docente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Persona = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docentes", x => x.Id_Docente);
                    table.ForeignKey(
                        name: "FK_Docentes_Personas_Id_Persona",
                        column: x => x.Id_Persona,
                        principalTable: "Personas",
                        principalColumn: "Id_Persona",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id_Usuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre_Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clave_Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estatus_Usuario = table.Column<int>(type: "int", nullable: false),
                    Id_Persona = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id_Usuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Personas_Id_Persona",
                        column: x => x.Id_Persona,
                        principalTable: "Personas",
                        principalColumn: "Id_Persona",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario_Roles",
                columns: table => new
                {
                    Id_Usuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Rol = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario_Roles", x => new { x.Id_Usuario, x.Id_Rol });
                    table.ForeignKey(
                        name: "FK_Usuario_Roles_Roles_Id_Rol",
                        column: x => x.Id_Rol,
                        principalTable: "Roles",
                        principalColumn: "Id_Rol",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_Roles_Usuarios_Id_Usuario",
                        column: x => x.Id_Usuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_Id_Carrera",
                table: "Alumnos",
                column: "Id_Carrera");

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_Id_Persona",
                table: "Alumnos",
                column: "Id_Persona",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Docentes_Id_Persona",
                table: "Docentes",
                column: "Id_Persona",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Roles_Id_Rol",
                table: "Usuario_Roles",
                column: "Id_Rol");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Id_Persona",
                table: "Usuarios",
                column: "Id_Persona",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alumnos");

            migrationBuilder.DropTable(
                name: "Docentes");

            migrationBuilder.DropTable(
                name: "Usuario_Roles");

            migrationBuilder.DropTable(
                name: "Carreras");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
