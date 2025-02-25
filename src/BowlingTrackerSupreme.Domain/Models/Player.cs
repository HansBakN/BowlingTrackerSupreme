﻿namespace BowlingTrackerSupreme.Domain.Models;

public class Player
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime ModifiedOn { get; set; }

    public IEnumerable<Game> GameParticipation { get; set; } = [];
    public IEnumerable<PlayerGame> PlayedGames { get; set; } = [];
}