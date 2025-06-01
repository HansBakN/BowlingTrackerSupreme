namespace BowlingTrackerSupreme.Domain.Models
{
    public class PlayerNickname
    {
        public Guid Id { get; set; }
        
        public Guid PlayerId { get; set; }

        public Player Player { get; set; }

        public string Nickname { get; set; }
        
        public DateTime CreatedOn { get; set; }
        
        public DateTime ModifiedOn { get; set; }
    }
}
