using Interfaces;
using Repositories;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddScoped<IRepoUsuario, RepoUsuario>();
builder.Services.AddScoped<IRepoEquipo, RepoEquipo>();
builder.Services.AddScoped<IRepoJugador, RepoJugador>();
builder.Services.AddScoped<IRepoPosicion, RepoPosicion>();
builder.Services.AddScoped<IRepoPuntuacion, RepoPuntuacion>();
builder.Services.AddScoped<IRepoPlantilla, RepoPlantilla>();
builder.Services.AddScoped<IRepoPlantillaTitular, RepoPlantillaTitular>();
builder.Services.AddScoped<IRepoPlantillaSuplente, RepoPlantillaSuplente>();

builder.Services.AddScoped<ServiceUsuario>();
builder.Services.AddScoped<ServiceEquipo>();
builder.Services.AddScoped<ServiceJugador>();
builder.Services.AddScoped<ServicePosicion>();
builder.Services.AddScoped<ServicePuntuacion>();
builder.Services.AddScoped<ServicePlantilla>();
builder.Services.AddScoped<ServicePlantillaTitular>();
builder.Services.AddScoped<ServicePlantillaSuplente>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScallarReference();
}

app.UseHttpsRedirection();
app.MapControllers();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
