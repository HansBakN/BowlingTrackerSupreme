namespace BowlingTrackerSupreme.Blazor.DtoModels
{
    public class GamePlayerCreateDto
    {
        public Guid GameId { get; set; }
        public Guid PlayerId { get; set; }
        public Guid? PlayerNicknameId { get; set; }
        public int TotalScore { get; set; }
    }
}
