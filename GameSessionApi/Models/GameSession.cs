namespace GameSessionApi.Models;

/// <summary>
/// Représente une session de jeu vidéo
/// </summary>
public class GameSession
{
    public int Id { get; set; }
    public required string GameTitle { get; set; }
    public required string PlayerName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public int? Score { get; set; }
    public TimeSpan? Duration => EndTime?.Subtract(StartTime);
    public SessionStatus Status { get; set; } = SessionStatus.Active;
    public string? Notes { get; set; }
}

/// <summary>
/// Statut d'une session de jeu
/// </summary>
public enum SessionStatus
{
    Active,
    Completed,
    Paused,
    Abandoned
}