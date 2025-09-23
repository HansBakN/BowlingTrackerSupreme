using BowlingTrackerSupreme.Domain.Models;
using BowlingTrackerSupreme.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace BowlingTrackerSupreme.Web.Services
{
    public interface IGameService
    {
        Task<List<Game>> GetGames();
        Task<Guid> CreateGame();
    }


    public class GameService(BowlingTrackerSupremeDbContext context) : IGameService
    {
        public async Task<Guid> CreateGame()
        {
            throw new NotImplementedException();
        }
        //{
        //    var newGameId = new Game
        //    {
                
        //    }
        //}

        public async Task<List<Game>> GetGames()
        {
            return await context.Games.ToListAsync();
        }
    }
}
