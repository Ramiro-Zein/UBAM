using API_UBAM.DatabaseContext;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_UBAM.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UbamDbContext _context;

    public AuthController(UbamDbContext context)
    {
        _context = context;
    }
    
}