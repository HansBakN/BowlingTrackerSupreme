namespace BowlingTrackerSupreme.Domain.Models;

public class Game
{
    public Guid? Id { get; set; }
    
    public DateTime PlayedOn { get; set; }
    
    public int Lane { get; set; }
    
    public int GameNumber { get; set; }

    public IEnumerable<GamePlayer> Players { get; set; }
    
    public DateTime? CreatedOn { get; set; }
    
    public DateTime? ModifiedOn { get; set; }
}