using Microsoft.AspNetCore.Mvc;

namespace WEB_UBAM.Controllers;

public class LoginController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}