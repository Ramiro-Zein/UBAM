namespace API_UBAM.Models;

public class Rol
{
    public Guid Id_Rol { get; set; }
    public NombreRol Nombre_Rol { get; set; }
    
    public enum NombreRol
    {
        Administrador,
        Docente,
        Alumno
    }
}