namespace BowlingTrackerSupreme.Domain.Models;

public class Game
{
    public Guid Id { get; set; }
    public Player WinningPlayer { get; set; } = null!;
    public Guid WinningPlayerId { get; set; }
    public IEnumerable<PlayerGame> PlayerGames { get; set; } = [];
    public IEnumerable<Player> Participants { get; set; } = [];
}