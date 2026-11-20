using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Taller.Application;
using Taller.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

const string FrontendCors = "frontend";

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddOpenApi();
builder.Services.AddProblemDetails();

builder.Services.AddCors(options =>
{
    var origins = builder.Configuration.GetSection("Cors:Origins").Get<string[]>() ?? [];
    options.AddPolicy(FrontendCors, policy => policy
        .WithOrigins(origins)
        .AllowAnyHeader()
        .AllowAnyMethod());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseExceptionHandler();
app.UseStatusCodePages();
app.UseCors(FrontendCors);

// /health/live: la API responde. /health/ready: además la base de datos está disponible.
app.MapHealthChecks("/health/live", new HealthCheckOptions { Predicate = _ => false });
app.MapHealthChecks("/health/ready", new HealthCheckOptions { Predicate = check => check.Tags.Contains("ready") });

var api = app.MapGroup("/api");
api.MapGet("/version", () => new { nombre = "Taller API", version = "0.1.0" })
   .WithName("GetVersion");

app.Run();

// Permite que las pruebas de integración usen WebApplicationFactory<Program>.
public partial class Program;
