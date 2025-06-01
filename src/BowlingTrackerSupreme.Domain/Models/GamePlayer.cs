using System.Runtime.Serialization;

namespace BowlingTrackerSupreme.Domain.Models;

[DataContract(Name = nameof(GamePlayer))]
public class GamePlayer
{
    [DataMember(Name = nameof(Id))]
    public Guid? Id { get; set; }

    public Guid GameId { get; set; }

    [DataMember(Name = nameof(Game))]
    public Game Game { get; set; }

    public Guid PlayerId { get; set; }

    [DataMember(Name = nameof(Player))]
    public Player Player { get; set; }
    
    public Guid? PlayerNicknameId { get; set; }

    [DataMember(Name = nameof(PlayerNickname))]
    public PlayerNickname PlayerNickname { get; set; }

    [DataMember(Name = nameof(TotalScore))]
    public int TotalScore { get; set; }

    public IEnumerable<Frame> Frames { get; set; }
}