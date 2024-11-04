using Microsoft.AspNetCore.Mvc;
using WEB_UBAM.Models;

namespace WEB_UBAM.Controllers;

public class LoginController(HttpClient httpClient) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginSolicitar solicitar)
    {
        var response = await httpClient.PostAsJsonAsync("http://localhost:5200/api/auth/login", solicitar);

        if (response.IsSuccessStatusCode)
        {
            var authResponse = await response.Content.ReadFromJsonAsync<LoginRespuesta>();

            TempData["NombreCompleto"] = authResponse.Nombre_Persona_Login_Respuesta;
            TempData["Roles"] = string.Join(", ", authResponse.Roles_Login_Respuesta);

            return RedirectToAction("Index", "Inicio");
        }

        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
            TempData["ErrorMessage"] = "Verifique sus datos";
        }
        else
        {
            TempData["ErrorMessage"] = "Error con el servidor.";
        }

        return RedirectToAction("Index");
    }

    public IActionResult Logout()
    {
        return RedirectToAction("Index");
    }
}
