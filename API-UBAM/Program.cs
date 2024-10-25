using System.Text.Json.Serialization;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddProblemDetails();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.Run();

