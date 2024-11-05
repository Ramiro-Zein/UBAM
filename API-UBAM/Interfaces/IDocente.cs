using API_UBAM.Models;

namespace API_UBAM.Interfaces;

public interface IDocente
{
    Guid Id_Docente { get; set; }
    Guid Id_Persona { get; set; }
    Persona Persona { get; set; }
}