using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_UBAM.Migrations
{
    /// <inheritdoc />
    public partial class Upload_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { new Guid("a8902b2a-2345-6789-01bc-def123456789"), "$2a$11$S3BW/TJAOjY.Iqg2SbnFB.VQB2TM/4QPoaYIcv8KdJgYQH2vAaRdm", 1, new Guid("b350ce7b-6982-4439-9f00-7469a49e1b84"), "ramiro.zein" },
                    { new Guid("b9013c3b-3456-7890-12cd-efab34567890"), "$2a$11$6qSfvd.big5HkAHMVmAzdOXqqXMO6KpJExxITr47LHIPpnrB391Ee", 1, new Guid("c450de8c-7993-554a-af11-857ab5a2c95b"), "maria.lopez" }
                });

            migrationBuilder.InsertData(
                table: "Usuario_Roles",
                columns: new[] { "Id_Rol", "Id_Usuario" },
                values: new object[,]
                {
                    { new Guid("f7801a1f-1234-5678-90ab-cdef12345678"), new Guid("a8902b2a-2345-6789-01bc-def123456789") },
                    { new Guid("f7801a1f-1234-5678-90ab-cdef12345680"), new Guid("b9013c3b-3456-7890-12cd-efab34567890") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Alumnos",
                keyColumn: "Id_Alumno",
                keyValue: new Guid("e2346f6c-6789-0123-45fa-cdef67890123"));

            migrationBuilder.DeleteData(
                table: "Carreras",
                keyColumn: "Id_Carrera",
                keyValue: new Guid("d1235e5b-5678-9012-34ef-bcde56789012"));

            migrationBuilder.DeleteData(
                table: "Docentes",
                keyColumn: "Id_Docente",
                keyValue: new Guid("f3457e7d-7890-1234-56ab-defa78901234"));

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id_Persona",
                keyValue: new Guid("e670f0ae-99b5-776c-c123-a79cd7c4e17d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id_Rol",
                keyValue: new Guid("f7801a1f-1234-5678-90ab-cdef12345679"));

            migrationBuilder.DeleteData(
                table: "Usuario_Roles",
                keyColumns: new[] { "Id_Rol", "Id_Usuario" },
                keyValues: new object[] { new Guid("f7801a1f-1234-5678-90ab-cdef12345678"), new Guid("a8902b2a-2345-6789-01bc-def123456789") });

            migrationBuilder.DeleteData(
                table: "Usuario_Roles",
                keyColumns: new[] { "Id_Rol", "Id_Usuario" },
                keyValues: new object[] { new Guid("f7801a1f-1234-5678-90ab-cdef12345680"), new Guid("b9013c3b-3456-7890-12cd-efab34567890") });

            migrationBuilder.DeleteData(
                table: "Carreras",
                keyColumn: "Id_Carrera",
                keyValue: new Guid("c0124d4a-4567-8901-23de-fabc45678901"));

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id_Persona",
                keyValue: new Guid("d560ef9d-88a4-665b-b012-968bc6b3d06c"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id_Rol",
                keyValue: new Guid("f7801a1f-1234-5678-90ab-cdef12345678"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id_Rol",
                keyValue: new Guid("f7801a1f-1234-5678-90ab-cdef12345680"));

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id_Usuario",
                keyValue: new Guid("a8902b2a-2345-6789-01bc-def123456789"));

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id_Usuario",
                keyValue: new Guid("b9013c3b-3456-7890-12cd-efab34567890"));

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id_Persona",
                keyValue: new Guid("b350ce7b-6982-4439-9f00-7469a49e1b84"));

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id_Persona",
                keyValue: new Guid("c450de8c-7993-554a-af11-857ab5a2c95b"));
        }
    }
}
