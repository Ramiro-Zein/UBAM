using System.Text.Json;
using System.Text.Json.Serialization;
using API_UBAM.DatabaseContext;
using API_UBAM.DTO;
using API_UBAM.Interfaces;
using API_UBAM.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Agregar los controladores
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

// Conexión a base de datos
builder.Services.AddDbContext<UbamDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Servicios de autenticación
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication("Cookies")
    .AddCookie(options =>
    {
        options.LoginPath = "/api/auth/login";
        options.LogoutPath = "/api/auth/logout";
        options.Cookie.Name = "UbamAuthCookie";
    });


var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

// "DefaultConnection": "Server=SISTEMAS5;Database=ubam;User ID=zein;Password=1234;TrustServerCertificate=True;Connection Timeout=30;"
// "DefaultConnection": "Server=ZEIN;Database=ubam;User ID=ramiro;Password=123;TrustServerCertificate=True;Connection Timeout=30;"