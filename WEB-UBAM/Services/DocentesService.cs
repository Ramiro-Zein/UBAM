using WEB_UBAM.Models;

namespace WEB_UBAM.Services;

public class DocentesService
{
    private readonly HttpClient _httpClient;

    public DocentesService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Docente>> GetDocentes()
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<ApiResponse<Docente>>("Docentes");
            return response?.Values ?? new List<Docente>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener docentes: {ex.Message}");
            return new List<Docente>();
        }
    }
}