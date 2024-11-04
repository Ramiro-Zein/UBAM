using WEB_UBAM.Models;

namespace WEB_UBAM.Services;

public class AuthService
{
    private readonly HttpClient _httpClient;

    public AuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<LoginRespuesta?> AuthenticateAsync(LoginSolicitar solicitar)
    {
        var response = await _httpClient.PostAsJsonAsync("auth/login", solicitar);
        
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<LoginRespuesta>();
        }

        return null;
    }
}
