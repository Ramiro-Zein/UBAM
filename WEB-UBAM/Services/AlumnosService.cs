using WEB_UBAM.Models;

namespace WEB_UBAM.Services;

public class AlumnosService(HttpClient httpClient)
{
    public async Task<List<Alumno>> GetAlumno()
    {
        try
        {
            var response = await httpClient.GetFromJsonAsync<List<Alumno>>("Alumnos");
            return response ?? new List<Alumno>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener alumnos: {ex.Message}");
            return new List<Alumno>();
        }
    }
}