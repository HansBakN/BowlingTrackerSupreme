namespace BowlingTrackerSupreme.Domain.Models;

public class Game
{
    public Guid Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime ModifiedOn { get; set; }
    public DateTime PlayedOn { get; set; }
    public Player WinningPlayer { get; set; } = null!;
    public Guid WinningPlayerId { get; set; }
    public IEnumerable<PlayerGame> PlayerGames { get; set; } = [];
    public IEnumerable<Player> Participants { get; set; } = [];
}