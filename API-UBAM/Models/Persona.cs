using System.ComponentModel.DataAnnotations;

namespace API_UBAM.Models;

public class Persona
{
    public Guid Id_Persona { get; set; }
    public string Nombre_Persona { get; set; }
    public string Apellido_Paterno_Persona { get; set; }
    public string Apellido_Materno_Persona { get; set; }
    public DateOnly Fecha_Nacimiento_Persona { get; set; }
    public Sexo Sexo_Persona { get; set; }
    public string Curp_Persona { get; set; }
    
    public enum Sexo
    {
        Hombre,
        Mujer,
        [Display(Name = "No Definido")]
        NoDefinido
    }
}