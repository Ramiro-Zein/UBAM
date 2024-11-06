using API_UBAM.Models;

namespace API_UBAM.Interfaces;

public interface IUsuario
{
    Guid Id_Usuario { get; set; }
    string Nombre_Usuario { get; set; }
    string Clave_Usuario { get; set; }
    Usuario.Estatus Estatus_Usuario { get; set; }
    Guid Id_Persona { get; set; }
    Persona Persona { get; set; }
    ICollection<UsuarioRol> Usuario_Roles { get; set; }
}