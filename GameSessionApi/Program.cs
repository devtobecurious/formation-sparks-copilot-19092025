using GameSessionApi.Models;
using GameSessionApi.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IGameSessionService, InMemoryGameSessionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Game Session API Endpoints

// GET /sessions - Récupérer toutes les sessions
app.MapGet("/sessions", async (IGameSessionService service) =>
{
    var sessions = await service.GetAllSessionsAsync();
    return Results.Ok(sessions);
})
.WithName("GetAllSessions")
.WithOpenApi()
.WithSummary("Récupère toutes les sessions de jeu")
.WithDescription("Retourne la liste complète des sessions de jeu vidéo");

// GET /sessions/{id} - Récupérer une session par ID
app.MapGet("/sessions/{id:int}", async (int id, IGameSessionService service) =>
{
    var session = await service.GetSessionByIdAsync(id);
    return session is not null ? Results.Ok(session) : Results.NotFound();
})
.WithName("GetSessionById")
.WithOpenApi()
.WithSummary("Récupère une session par son ID")
.WithDescription("Retourne les détails d'une session de jeu spécifique");

// POST /sessions - Créer une nouvelle session
app.MapPost("/sessions", async ([FromBody] CreateGameSessionDto createDto, IGameSessionService service) =>
{
    try
    {
        var session = await service.CreateSessionAsync(createDto);
        return Results.Created($"/sessions/{session.Id}", session);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
})
.WithName("CreateSession")
.WithOpenApi()
.WithSummary("Crée une nouvelle session de jeu")
.WithDescription("Démarre une nouvelle session de jeu vidéo");

// PUT /sessions/{id} - Mettre à jour une session
app.MapPut("/sessions/{id:int}", async (int id, [FromBody] UpdateGameSessionDto updateDto, IGameSessionService service) =>
{
    var session = await service.UpdateSessionAsync(id, updateDto);
    return session is not null ? Results.Ok(session) : Results.NotFound();
})
.WithName("UpdateSession")
.WithOpenApi()
.WithSummary("Met à jour une session de jeu")
.WithDescription("Modifie les informations d'une session de jeu existante");

// DELETE /sessions/{id} - Supprimer une session
app.MapDelete("/sessions/{id:int}", async (int id, IGameSessionService service) =>
{
    var deleted = await service.DeleteSessionAsync(id);
    return deleted ? Results.NoContent() : Results.NotFound();
})
.WithName("DeleteSession")
.WithOpenApi()
.WithSummary("Supprime une session de jeu")
.WithDescription("Supprime définitivement une session de jeu");

// GET /sessions/player/{playerName} - Récupérer les sessions d'un joueur
app.MapGet("/sessions/player/{playerName}", async (string playerName, IGameSessionService service) =>
{
    var sessions = await service.GetSessionsByPlayerAsync(playerName);
    return Results.Ok(sessions);
})
.WithName("GetSessionsByPlayer")
.WithOpenApi()
.WithSummary("Récupère les sessions d'un joueur")
.WithDescription("Retourne toutes les sessions de jeu d'un joueur spécifique");

// GET /sessions/game/{gameTitle} - Récupérer les sessions d'un jeu
app.MapGet("/sessions/game/{gameTitle}", async (string gameTitle, IGameSessionService service) =>
{
    var sessions = await service.GetSessionsByGameAsync(gameTitle);
    return Results.Ok(sessions);
})
.WithName("GetSessionsByGame")
.WithOpenApi()
.WithSummary("Récupère les sessions d'un jeu")
.WithDescription("Retourne toutes les sessions pour un jeu vidéo spécifique");

app.Run();
