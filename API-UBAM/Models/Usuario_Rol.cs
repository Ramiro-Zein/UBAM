using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_UBAM.Models;

public class Usuario_Rol
{
    [Key, Column(Order = 0)] public Guid Id_Usuario { get; set; }

    [Key, Column(Order = 1)] public Guid Id_Rol { get; set; }

    public Usuario Usuario { get; set; }
    public Rol Rol { get; set; }
}