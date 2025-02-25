namespace BowlingTrackerSupreme.Domain.Models;

public class Frame
{
    public Guid Id { get; set; }
    public Guid PlayerGameId { get; set; }
    public PlayerGame PlayerGame { get; set; } = null!;
    
    public Guid FirstRollId { get; set; }
    public Roll FirstRoll { get; set; } = null!;
    public Guid SecondRollId { get; set; }
    public Roll? SecondRoll { get; set; } 
    public virtual IEnumerable<Roll?> AllRolls => 
    [
        FirstRoll, 
        SecondRoll,
    ];
    public bool IsStrike => FirstRoll.PinsHit == 10;
    public bool IsSpare => SecondRoll != null && (SecondRoll.PinsHit + FirstRoll.PinsHit) == 10; 
    public virtual int FrameNumber { get; set; }
    public int? Score { get; set; }
}