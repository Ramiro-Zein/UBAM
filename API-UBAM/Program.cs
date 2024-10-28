using System.Text.Json.Serialization;
using API_UBAM.DatabaseContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });

builder.Services.AddDbContext<UbamDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.MapControllers();
app.Run();

// "DefaultConnection": "Server=SISTEMAS5;Database=ubam;User ID=zein;Password=1234;TrustServerCertificate=True;Connection Timeout=30;"
// "DefaultConnection": "Server=ZEIN;Database=ubam;User ID=ramiro;Password=123;TrustServerCertificate=True;Connection Timeout=30;"