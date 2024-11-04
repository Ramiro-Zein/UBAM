using System.ComponentModel.DataAnnotations;

namespace WEB_UBAM.Models;

public class LoginSolicitar
{
    [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
    public string Nombre_Usuario { get; set; }

    [Required(ErrorMessage = "La clave es obligatoria.")]
    public string Clave_Usuario { get; set; }
}