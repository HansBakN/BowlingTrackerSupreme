namespace BowlingTrackerSupreme.Domain.Models
{
    public class ApiKey
    {
        public Guid Id { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
