using WEB_UBAM.Services;

namespace WEB_UBAM.Extensions;

public static class HttpClientApi
{
    public static void AddCustomHttpClients(this IServiceCollection services, string? apiBaseAddress)
    {
        services.AddHttpClient<AuthService>(client =>
        {
            client.BaseAddress = new Uri(apiBaseAddress);
        });
        services.AddHttpClient<AlumnosService>(client =>
        {
            client.BaseAddress = new Uri(apiBaseAddress);
        });

        services.AddHttpClient<DocentesService>(client =>
        {
            client.BaseAddress = new Uri(apiBaseAddress);
        });
    }
}