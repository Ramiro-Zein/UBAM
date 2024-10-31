using API_UBAM.DatabaseContext;
using Microsoft.AspNetCore.Mvc;

namespace API_UBAM.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : Controller
{
    private readonly UbamDbContext _context;

    public UsuarioController(UbamDbContext context)
    {
        _context = context;
    }
    
}