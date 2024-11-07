using WEB_UBAM.Models;

namespace WEB_UBAM.Services;

public class DocentesService(HttpClient httpClient)
{
    public async Task<List<Docente>> GetDocentes()
    {
        try
        {
            var response = await httpClient.GetFromJsonAsync<List<Docente>>("Docentes");
            return response ?? new List<Docente>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener docentes: {ex.Message}");
            return new List<Docente>();
        }
    }
}