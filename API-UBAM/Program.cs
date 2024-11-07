using System.Text.Json;
using System.Text.Json.Serialization;
using API_UBAM.DatabaseContext;
using API_UBAM.DTO;
using API_UBAM.Extensions;
using API_UBAM.Interfaces;
using API_UBAM.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProjectServices(builder.Configuration);

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

// "DefaultConnection": "Server=SISTEMAS5;Database=ubam;User ID=zein;Password=1234;TrustServerCertificate=True;Connection Timeout=30;"
// "DefaultConnection": "Server=ZEIN;Database=ubam;User ID=ramiro;Password=123;TrustServerCertificate=True;Connection Timeout=30;"