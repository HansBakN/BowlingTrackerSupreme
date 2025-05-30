namespace BowlingTrackerSupreme.Domain.Models;

public class GamePlayer
{
    public Guid Id { get; set; }

    public Guid GameId { get; set; }

    public Game Game { get; set; }

    public Guid PlayerId { get; set; }

    public Player Player { get; set; }
    
    public Guid? PlayerNicknameId { get; set; }
    
    public PlayerNickname PlayerNickname { get; set; }

    public int TotalScore { get; set; }

    public IEnumerable<Frame> Frames { get; set; }
}