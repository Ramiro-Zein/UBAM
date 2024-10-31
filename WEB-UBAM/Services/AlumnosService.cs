using WEB_UBAM.Models;

namespace WEB_UBAM.Services;

public class AlumnosService
{
    private readonly HttpClient _httpClient;

    public AlumnosService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Alumno>> GetAlumno()
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<ApiResponse<Alumno>>("Alumnos");
            return response?.Values ?? new List<Alumno>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener alumnos: {ex.Message}");
            return new List<Alumno>();
        }
    }
}