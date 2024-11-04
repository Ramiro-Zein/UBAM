namespace API_UBAM.DTO;

public class PersonaDto
{
    public string Nombre { get; set; }
    public string ApellidoPaterno { get; set; }
    public string ApellidoMaterno { get; set; }
    public DateOnly FechaNacimiento { get; set; }
    public int Sexo { get; set; }
    public string Curp { get; set; }
}
