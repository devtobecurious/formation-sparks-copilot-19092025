using GameSessionApi.Models;

namespace GameSessionApi.Services;

/// <summary>
/// Interface pour le service de gestion des sessions de jeu
/// </summary>
public interface IGameSessionService
{
    Task<IEnumerable<GameSession>> GetAllSessionsAsync();
    Task<GameSession?> GetSessionByIdAsync(int id);
    Task<GameSession> CreateSessionAsync(CreateGameSessionDto createDto);
    Task<GameSession?> UpdateSessionAsync(int id, UpdateGameSessionDto updateDto);
    Task<bool> DeleteSessionAsync(int id);
    Task<IEnumerable<GameSession>> GetSessionsByPlayerAsync(string playerName);
    Task<IEnumerable<GameSession>> GetSessionsByGameAsync(string gameTitle);
}

/// <summary>
/// Service en mémoire pour la gestion des sessions de jeu
/// </summary>
public class InMemoryGameSessionService : IGameSessionService
{
    private readonly List<GameSession> _sessions = new();
    private int _nextId = 1;

    public Task<IEnumerable<GameSession>> GetAllSessionsAsync()
    {
        return Task.FromResult(_sessions.AsEnumerable());
    }

    public Task<GameSession?> GetSessionByIdAsync(int id)
    {
        var session = _sessions.FirstOrDefault(s => s.Id == id);
        return Task.FromResult(session);
    }

    public Task<GameSession> CreateSessionAsync(CreateGameSessionDto createDto)
    {
        var session = new GameSession
        {
            Id = _nextId++,
            GameTitle = createDto.GameTitle,
            PlayerName = createDto.PlayerName,
            StartTime = DateTime.UtcNow,
            Status = SessionStatus.Active,
            Notes = createDto.Notes
        };

        _sessions.Add(session);
        return Task.FromResult(session);
    }

    public Task<GameSession?> UpdateSessionAsync(int id, UpdateGameSessionDto updateDto)
    {
        var session = _sessions.FirstOrDefault(s => s.Id == id);
        if (session == null)
            return Task.FromResult<GameSession?>(null);

        if (!string.IsNullOrWhiteSpace(updateDto.GameTitle))
            session.GameTitle = updateDto.GameTitle;
        
        if (!string.IsNullOrWhiteSpace(updateDto.PlayerName))
            session.PlayerName = updateDto.PlayerName;
        
        if (updateDto.EndTime.HasValue)
            session.EndTime = updateDto.EndTime.Value;
        
        if (updateDto.Score.HasValue)
            session.Score = updateDto.Score.Value;
        
        if (updateDto.Status.HasValue)
            session.Status = updateDto.Status.Value;
        
        if (updateDto.Notes != null)
            session.Notes = updateDto.Notes;

        return Task.FromResult<GameSession?>(session);
    }

    public Task<bool> DeleteSessionAsync(int id)
    {
        var session = _sessions.FirstOrDefault(s => s.Id == id);
        if (session == null)
            return Task.FromResult(false);

        _sessions.Remove(session);
        return Task.FromResult(true);
    }

    public Task<IEnumerable<GameSession>> GetSessionsByPlayerAsync(string playerName)
    {
        var sessions = _sessions.Where(s => 
            s.PlayerName.Contains(playerName, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(sessions);
    }

    public Task<IEnumerable<GameSession>> GetSessionsByGameAsync(string gameTitle)
    {
        var sessions = _sessions.Where(s => 
            s.GameTitle.Contains(gameTitle, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(sessions);
    }
}