using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
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

    /*
    [HttpPost]
    public async Task<IActionResult> Login(LoginSolicitarDto loginDto)
    {

    }

    public IActionResult Logout()
    {

    }
    */
}