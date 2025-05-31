using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BowlingTrackerSupreme.Domain.Models;

[DataContract(Name = nameof(Player))]
public class Player
{
    [DataMember(Name = nameof(Id))]
    public Guid? Id { get; set; }

    [DataMember(Name = nameof(UserName))]
    [Required]
    public string UserName { get; set; }

    [DataMember(Name = nameof(CreatedOn))]
    public DateTime? CreatedOn { get; set; }

    [DataMember(Name = nameof(ModifiedOn))]
    public DateTime? ModifiedOn { get; set; }

    public IEnumerable<GamePlayer> GameParticipations { get; set; }

    public IEnumerable<PlayerNickname> Nicknames { get; set; }
}