using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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

            migrationBuilder.InsertData(
                table: "Carreras",
                columns: new[] { "Id_Carrera", "Nombre_Carrera" },
                values: new object[,]
                {
                    { new Guid("c0124d4a-4567-8901-23de-fabc45678901"), 18 },
                    { new Guid("d1235e5b-5678-9012-34ef-bcde56789012"), 0 }
                });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "Id_Persona", "Apellido_Materno_Persona", "Apellido_Paterno_Persona", "Curp_Persona", "Fecha_Nacimiento_Persona", "Nombre_Persona", "Sexo_Persona" },
                values: new object[,]
                {
                    { new Guid("b350ce7b-6982-4439-9f00-7469a49e1b84"), "Rangel", "Contreras", "CORR900524HDFRRL04", new DateOnly(2003, 9, 25), "Ramiro Zein", 0 },
                    { new Guid("c450de8c-7993-554a-af11-857ab5a2c95b"), "Hernández", "López", "LOHM920815MDFRRL05", new DateOnly(1992, 8, 15), "María", 1 },
                    { new Guid("d560ef9d-88a4-665b-b012-968bc6b3d06c"), "Martínez", "Ramírez", "RAMC850310HDFRRL06", new DateOnly(1985, 3, 10), "Carlos", 0 },
                    { new Guid("e670f0ae-99b5-776c-c123-a79cd7c4e17d"), "Silva", "González", "GOSA951205MDFRRL07", new DateOnly(1995, 12, 5), "Ana", 1 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id_Rol", "Nombre_Rol" },
                values: new object[,]
                {
                    { new Guid("f7801a1f-1234-5678-90ab-cdef12345678"), 0 },
                    { new Guid("f7801a1f-1234-5678-90ab-cdef12345679"), 1 },
                    { new Guid("f7801a1f-1234-5678-90ab-cdef12345680"), 2 }
                });

            migrationBuilder.InsertData(
                table: "Alumnos",
                columns: new[] { "Id_Alumno", "Grupo_Alumno", "Id_Carrera", "Id_Persona" },
                values: new object[] { new Guid("e2346f6c-6789-0123-45fa-cdef67890123"), "Sistemas 101", new Guid("c0124d4a-4567-8901-23de-fabc45678901"), new Guid("c450de8c-7993-554a-af11-857ab5a2c95b") });

            migrationBuilder.InsertData(
                table: "Docentes",
                columns: new[] { "Id_Docente", "Id_Persona" },
                values: new object[] { new Guid("f3457e7d-7890-1234-56ab-defa78901234"), new Guid("d560ef9d-88a4-665b-b012-968bc6b3d06c") });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id_Usuario", "Clave_Usuario", "Estatus_Usuario", "Id_Persona", "Nombre_Usuario" },
                values: new object[,]
                {
                    { new Guid("a8902b2a-2345-6789-01bc-def123456789"), "$2a$11$CP.9YFNoCapDBQqN2lCLBu3Q61gNwOOjAGg8u/4sw5E.ym1244.N2", 1, new Guid("b350ce7b-6982-4439-9f00-7469a49e1b84"), "ramiro.zein" },
                    { new Guid("b9013c3b-3456-7890-12cd-efab34567890"), "$2a$11$lr8gRm9jUuSvF7Kabr9s2eD3fSCY4/uTHHbNMD/hPnMnN5Us2CwOq", 1, new Guid("c450de8c-7993-554a-af11-857ab5a2c95b"), "maria.lopez" }
                });

            migrationBuilder.InsertData(
                table: "Usuario_Roles",
                columns: new[] { "Id_Rol", "Id_Usuario" },
                values: new object[,]
                {
                    { new Guid("f7801a1f-1234-5678-90ab-cdef12345678"), new Guid("a8902b2a-2345-6789-01bc-def123456789") },
                    { new Guid("f7801a1f-1234-5678-90ab-cdef12345680"), new Guid("b9013c3b-3456-7890-12cd-efab34567890") }
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
