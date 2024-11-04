using API_UBAM.Models;
using Microsoft.EntityFrameworkCore;

namespace API_UBAM.DatabaseContext;

public class UbamDbContext : DbContext
{
    public UbamDbContext(DbContextOptions<UbamDbContext> options) : base(options)
    {
    }

    public DbSet<Persona> Personas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<Usuario_Rol> Usuario_Roles { get; set; }
    public DbSet<Alumno> Alumnos { get; set; }
    public DbSet<Docente> Docentes { get; set; }
    public DbSet<Carrera> Carreras { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Clave Usuario_Rol
        modelBuilder.Entity<Usuario_Rol>()
            .HasKey(ur => new { ur.Id_Usuario, ur.Id_Rol });

        // Relación uno a uno entre Usuario y Persona
        modelBuilder.Entity<Usuario>()
            .HasOne(u => u.Persona)
            .WithOne(p => p.Usuario)
            .HasForeignKey<Usuario>(u => u.Id_Persona);

        // Relación uno a uno entre Alumno y Persona
        modelBuilder.Entity<Alumno>()
            .HasOne(a => a.Persona)
            .WithOne(p => p.Alumno)
            .HasForeignKey<Alumno>(a => a.Id_Persona);

        // Relación uno a uno entre Docente y Persona
        modelBuilder.Entity<Docente>()
            .HasOne(d => d.Persona)
            .WithOne(p => p.Docente)
            .HasForeignKey<Docente>(d => d.Id_Persona);

        // Relación muchos a muchos entre Usuario y Rol
        modelBuilder.Entity<Usuario_Rol>()
            .HasOne(ur => ur.Usuario)
            .WithMany(u => u.Usuario_Roles)
            .HasForeignKey(ur => ur.Id_Usuario);

        modelBuilder.Entity<Usuario_Rol>()
            .HasOne(ur => ur.Rol)
            .WithMany(r => r.Usuario_Roles)
            .HasForeignKey(ur => ur.Id_Rol);

        // Relación muchos a uno entre Alumno y Carrera
        modelBuilder.Entity<Alumno>()
            .HasOne(a => a.Carrera)
            .WithMany(c => c.Alumnos)
            .HasForeignKey(a => a.Id_Carrera);

        var persona1Id = Guid.Parse("b350ce7b-6982-4439-9f00-7469a49e1b84");
        var persona2Id = Guid.Parse("c450de8c-7993-554a-af11-857ab5a2c95b");
        var persona3Id = Guid.Parse("d560ef9d-88a4-665b-b012-968bc6b3d06c");
        var persona4Id = Guid.Parse("e670f0ae-99b5-776c-c123-a79cd7c4e17d");
        var persona5Id = Guid.Parse("e670f0ae-99b5-776c-c123-a79cd7c4e17a");
        var persona6Id = Guid.Parse("a670f0ae-99b5-776c-c123-a79cd7c4e17a");

        modelBuilder.Entity<Persona>().HasData(
            new Persona
            {
                Id_Persona = persona1Id,
                Nombre_Persona = "Ramiro Zein",
                Apellido_Paterno_Persona = "Contreras",
                Apellido_Materno_Persona = "Rangel",
                Fecha_Nacimiento_Persona = new DateOnly(2003, 9, 25),
                Sexo_Persona = Persona.Sexo.Hombre,
                Curp_Persona = "CORR900524HDFRRL04"
            },
            new Persona
            {
                Id_Persona = persona6Id,
                Nombre_Persona = "Elizabeth",
                Apellido_Paterno_Persona = "Ortiz",
                Apellido_Materno_Persona = "Canales",
                Fecha_Nacimiento_Persona = new DateOnly(2004, 11, 10),
                Sexo_Persona = Persona.Sexo.Mujer,
                Curp_Persona = "GOSA951205MDFRRL08"
            },
            new Persona
            {
                Id_Persona = persona2Id,
                Nombre_Persona = "María",
                Apellido_Paterno_Persona = "López",
                Apellido_Materno_Persona = "Hernández",
                Fecha_Nacimiento_Persona = new DateOnly(1992, 8, 15),
                Sexo_Persona = Persona.Sexo.Mujer,
                Curp_Persona = "LOHM920815MDFRRL05"
            },
            new Persona
            {
                Id_Persona = persona3Id,
                Nombre_Persona = "Carlos",
                Apellido_Paterno_Persona = "Ramírez",
                Apellido_Materno_Persona = "Martínez",
                Fecha_Nacimiento_Persona = new DateOnly(1985, 3, 10),
                Sexo_Persona = Persona.Sexo.Hombre,
                Curp_Persona = "RAMC850310HDFRRL06"
            },
            new Persona
            {
                Id_Persona = persona4Id,
                Nombre_Persona = "Ana",
                Apellido_Paterno_Persona = "González",
                Apellido_Materno_Persona = "Silva",
                Fecha_Nacimiento_Persona = new DateOnly(1995, 12, 5),
                Sexo_Persona = Persona.Sexo.Mujer,
                Curp_Persona = "GOSA951205MDFRRL07"
            },
            new Persona
            {
                Id_Persona = persona5Id,
                Nombre_Persona = "Juanito",
                Apellido_Paterno_Persona = "González",
                Apellido_Materno_Persona = "Silva",
                Fecha_Nacimiento_Persona = new DateOnly(1995, 12, 5),
                Sexo_Persona = Persona.Sexo.Mujer,
                Curp_Persona = "GOSA951205MDFRRL07"
            }
            
        );

        // 2. Roles
        var rolAdminId = Guid.Parse("f7801a1f-1234-5678-90ab-cdef12345678");
        var rolDocenteId = Guid.Parse("f7801a1f-1234-5678-90ab-cdef12345679");
        var rolAlumnoId = Guid.Parse("f7801a1f-1234-5678-90ab-cdef12345680");

        modelBuilder.Entity<Rol>().HasData(
            new Rol
            {
                Id_Rol = rolAdminId,
                Nombre_Rol = Rol.NombreRol.Administrador
            },
            new Rol
            {
                Id_Rol = rolDocenteId,
                Nombre_Rol = Rol.NombreRol.Docente
            },
            new Rol
            {
                Id_Rol = rolAlumnoId,
                Nombre_Rol = Rol.NombreRol.Alumno
            }
        );

        // 3. Usuarios
        var usuario1Id = Guid.Parse("a8902b2a-2345-6789-01bc-def123456789");
        var usuario2Id = Guid.Parse("b9013c3b-3456-7890-12cd-efab34567890");
        var usuario3Id = Guid.Parse("c9013c3b-3456-7890-12cd-efab34567890");
        
        modelBuilder.Entity<Usuario>().HasData(
            new Usuario
            {
                Id_Usuario = usuario1Id,
                Nombre_Usuario = "ramiro.zein",
                Clave_Usuario = BCrypt.Net.BCrypt.HashPassword("1234"),
                Estatus_Usuario = Usuario.Estatus.Activo,
                Id_Persona = persona1Id
            },
            new Usuario
            {
                Id_Usuario = usuario3Id,
                Nombre_Usuario = "eli.ortiz",
                Clave_Usuario = BCrypt.Net.BCrypt.HashPassword("123"),
                Estatus_Usuario = Usuario.Estatus.Activo,
                Id_Persona = persona6Id
            },
            new Usuario
            {
                Id_Usuario = usuario2Id,
                Nombre_Usuario = "maria.lopez",
                Clave_Usuario = BCrypt.Net.BCrypt.HashPassword("Password456"),
                Estatus_Usuario = Usuario.Estatus.Activo,
                Id_Persona = persona2Id
            }
        );

        // 4. Usuario_Rol
        modelBuilder.Entity<Usuario_Rol>().HasData(
            new Usuario_Rol
            {
                Id_Usuario = usuario1Id,
                Id_Rol = rolAdminId
            },
            new Usuario_Rol
            {
                Id_Usuario = usuario2Id,
                Id_Rol = rolDocenteId
            },
            new Usuario_Rol
            {
                Id_Usuario = usuario3Id,
                Id_Rol = rolAdminId
            }
        );

        // 5. Carreras
        var carrera1Id = Guid.Parse("c0124d4a-4567-8901-23de-fabc45678901");
        var carrera2Id = Guid.Parse("d1235e5b-5678-9012-34ef-bcde56789012");

        modelBuilder.Entity<Carrera>().HasData(
            new Carrera
            {
                Id_Carrera = carrera1Id,
                Nombre_Carrera = Carrera.NombreCarrera.IngenieriaEnSistemasComputacionales
            },
            new Carrera
            {
                Id_Carrera = carrera2Id,
                Nombre_Carrera = Carrera.NombreCarrera.AdministracionDeEmpresas
            }
        );

        // 6. Alumnos
        var alumno1Id = Guid.Parse("e2346f6c-6789-0123-45fa-cdef67890123");
        var alumno2Id = Guid.Parse("e2346f6c-6789-0123-45fa-cdef67890124");

        modelBuilder.Entity<Alumno>().HasData(
            new Alumno
            {
                Id_Alumno = alumno1Id,
                Grupo_Alumno = "Sistemas 101",
                Id_Persona = persona2Id,
                Id_Carrera = carrera1Id
            },
            new Alumno
            {
                Id_Alumno = alumno2Id,
                Grupo_Alumno = "Sistemas 102",
                Id_Persona = persona5Id,
                Id_Carrera = carrera1Id
            }
        );

        // 7. Docentes
        var docente1Id = Guid.Parse("f3457e7d-7890-1234-56ab-defa78901234");

        modelBuilder.Entity<Docente>().HasData(
            new Docente
            {
                Id_Docente = docente1Id,
                Id_Persona = persona3Id
            }
        );

        base.OnModelCreating(modelBuilder);
    }
}