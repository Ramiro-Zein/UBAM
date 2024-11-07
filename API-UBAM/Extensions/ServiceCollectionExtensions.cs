using System.Text.Json.Serialization;
using API_UBAM.DatabaseContext;
using API_UBAM.Interfaces;
using API_UBAM.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace API_UBAM.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddProjectServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
        });

        // Configuración de Controladores y Opciones JSON
        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });

        // Configuración de la base de datos
        services.AddDbContext<UbamDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // Configuración de Autenticación
        services.AddScoped<IAuthService, AuthService>();
        services.AddHttpContextAccessor();
        services.AddAuthentication("Cookies")
            .AddCookie(options =>
            {
                options.LoginPath = "/api/auth/login";
                options.LogoutPath = "/api/auth/logout";
                options.Cookie.Name = "UbamAuthCookie";
            });
    }
}