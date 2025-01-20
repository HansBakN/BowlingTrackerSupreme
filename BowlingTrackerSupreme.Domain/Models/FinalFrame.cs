namespace BowlingTrackerSupreme.Domain.Models;

public class FinalFrame : Frame
{
    public Roll? ThirdRoll { get; set; }
    public override int FrameNumber => 10;
    public override IEnumerable<Roll?> AllRolls => 
        [
            FirstRoll,
            SecondRoll,
            ThirdRoll,
        ];
}