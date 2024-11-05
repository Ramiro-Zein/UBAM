using WEB_UBAM.Models;

namespace WEB_UBAM.Services;

public class AuthService(HttpClient httpClient)
{
    public async Task<LoginRespuesta?> AuthenticateAsync(LoginSolicitar solicitar)
    {
        var response = await httpClient.PostAsJsonAsync("auth/login", solicitar);
        
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<LoginRespuesta>();
        }

        return null;
    }
}
