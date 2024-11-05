using Microsoft.AspNetCore.Authorization;

namespace WEB_UBAM.Extensions;

public class AuthorizationPolicies
{
    public static void AddAuthorizationPolicies(AuthorizationOptions options)
    {
        options.AddPolicy("Administrador", policy => policy.RequireRole("Administrador"));
        options.AddPolicy("Docente", policy => policy.RequireRole("Docente"));
        options.AddPolicy("Alumno", policy => policy.RequireRole("Alumno"));
    }
}