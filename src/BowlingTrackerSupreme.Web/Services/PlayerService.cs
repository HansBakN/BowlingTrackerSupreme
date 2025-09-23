using BowlingTrackerSupreme.Domain.Models;
using BowlingTrackerSupreme.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace BowlingTrackerSupreme.Web.Services
{
    public interface IPlayerService
    {
        Task<Guid> CreatePlayer(string playerName);
        Task<Player> GetPlayerById(Guid id);
        Task<List<Player>> GetAllPlayers();
    }

    public class PlayerService(BowlingTrackerSupremeDbContext context) : IPlayerService
    {
        public async Task<Guid> CreatePlayer(string playerName)
        {
            var newPlayer = new Player
            {
                Name = playerName
            };

            await context.AddAsync(newPlayer);
            await context.SaveChangesAsync();

            return newPlayer.Id;
        }

        public async Task<Player> GetPlayerById(Guid id)
        {
            var player = await context.Players.FirstOrDefaultAsync(p => p.Id == id);

            if(player == null)
            {
                return new Player { Name = "" };
            }

            return player;
        }

        public async Task<List<Player>> GetAllPlayers()
        {
            var players = await context.Players.ToListAsync();

            return players;
        }

    }
}
