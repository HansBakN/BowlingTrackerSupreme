namespace BowlingTrackerSupreme.Domain.Models;

public class PlayerGame
{
    public Guid Id { get; set; }
    public Guid PlayerId { get; set; }
    public Player Player { get; set; } = null!;
    public Guid GameId { get; set; }
    public Game Game { get; set; } = null!;
    public IEnumerable<Frame> Frames { get; set; } = [];
}