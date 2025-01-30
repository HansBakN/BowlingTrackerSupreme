namespace BowlingTrackerSupreme.Domain.Models
{
    public class TheCounter
    {
        /// <summary>
        /// Counter unique ID.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Counter name.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Current value of the counter.
        /// </summary>
        public int Value { get; set; }
    }
}
