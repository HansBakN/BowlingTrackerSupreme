namespace BowlingTrackerSupreme.Domain.Models;

public class Frame
{
    public Guid Id { get; set; }
    
    public Guid GamePlayerId { get; set; }

    public GamePlayer GamePlayer { get; set; }

    public int Index { get; set; }

    public int FirstRoll { get; set; }
    
    public int SecondRoll { get; set; }
    
    public int ThirdRoll { get; set; }

    public int AccumulatedScore { get; set; }
    
    public int Score { get; set; }
}