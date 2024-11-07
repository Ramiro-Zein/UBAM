using WEB_UBAM.DTO;
using WEB_UBAM.Models;

namespace WEB_UBAM.Services;

public class PersonasService(HttpClient httpClient)
{
    public async Task<List<PersonaDto>> GetPersonas()
    {
        try
        {
            var response  = await httpClient.GetFromJsonAsync<List<PersonaDto>>("Personas");
            return response ?? new List<PersonaDto>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener personas: {ex.Message}");
            return new List<PersonaDto>();
        }
    }
}