namespace GameSessionApi.Models;

/// <summary>
/// DTO pour la création d'une nouvelle session de jeu
/// </summary>
public class CreateGameSessionDto
{
    public required string GameTitle { get; set; }
    public required string PlayerName { get; set; }
    public string? Notes { get; set; }
}

/// <summary>
/// DTO pour la mise à jour d'une session de jeu
/// </summary>
public class UpdateGameSessionDto
{
    public string? GameTitle { get; set; }
    public string? PlayerName { get; set; }
    public DateTime? EndTime { get; set; }
    public int? Score { get; set; }
    public SessionStatus? Status { get; set; }
    public string? Notes { get; set; }
}