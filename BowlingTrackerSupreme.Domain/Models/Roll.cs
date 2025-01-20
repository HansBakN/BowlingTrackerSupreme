namespace BowlingTrackerSupreme.Domain.Models;

public class Roll
{
    public Guid Id { get; set; }
    public Guid FrameId { get; set; }
    public Frame Frame { get; set; } = null!;
    public int PinsHit { get; set; }
}