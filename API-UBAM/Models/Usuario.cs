namespace API_UBAM.Models;

public class Usuario
{
    public Guid Id_Usuario { get; set; }
    public string Nombre_Usuario { get; set; }
    public string Clave_Usuario { get; set; }
    public Estatus Estatus_Usuario { get; set; }
    
    public enum Estatus
    {
        Inactivo,
        Activo
    }
}