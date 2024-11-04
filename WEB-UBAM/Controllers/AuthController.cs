using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WEB_UBAM.Models;
using WEB_UBAM.Services;

namespace WEB_UBAM.Controllers;

public class AuthController(AuthService authService) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Index", "Inicio");
        }

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginSolicitar solicitar)
    {
        try
        {
            var authResponse = await authService.AuthenticateAsync(solicitar);

            if (authResponse != null && !string.IsNullOrEmpty(authResponse.Nombre_Completo))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, authResponse.Nombre_Completo)
                };

                if (authResponse.Roles?.Values != null && authResponse.Roles.Values.Any())
                {
                    foreach (var rol in authResponse.Roles.Values)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, rol));
                    }
                }

                var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");
                await HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Inicio");
            }

            TempData["ErrorMessage"] = "Verifique sus datos.";
            return RedirectToAction("Index");
        }
        catch (Exception)
        {
            TempData["ErrorMessage"] = "Inténtelo más tarde.";
            return RedirectToAction("Index");
        }
    }
    
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync("CookieAuth");
        return RedirectToAction("Index", "Auth");
    }
}