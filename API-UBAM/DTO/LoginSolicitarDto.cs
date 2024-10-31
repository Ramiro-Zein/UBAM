using System.ComponentModel.DataAnnotations;

namespace API_UBAM.DTO;

public class LoginSolicitarDto
{
    [Required]
    public string Nombre_Usuario { get; set; }
    
    [Required]
    public string Clave_Usuario { get; set; }
}