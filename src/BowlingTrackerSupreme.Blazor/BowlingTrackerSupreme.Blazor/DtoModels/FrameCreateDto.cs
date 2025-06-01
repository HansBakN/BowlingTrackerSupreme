namespace BowlingTrackerSupreme.Blazor.DtoModels
{
    public class FrameCreateDto
    {
        public Guid GamePlayerId { get; set; }

        public int Index { get; set; }
            
        public int FirstRoll { get; set; }
            
        public int SecondRoll { get; set; }
            
        public int? ThirdRoll { get; set; }
    }
}
