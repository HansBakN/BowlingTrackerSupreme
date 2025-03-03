using BowlingTrackerSupreme.Domain.Models;
using BowlingTrackerSupreme.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace BowlingTrackerSupreme.Blazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly BowlingTrackerSupremeDbContext _context;

        public GamesController(BowlingTrackerSupremeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var games = await _context.Games.ToListAsync();

            return new OkObjectResult(games);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody][Required] Game game)
        {
            if (game.Id.HasValue) game.Id = null;
            if (game.CreatedOn.HasValue) game.CreatedOn = null;
            if (game.ModifiedOn.HasValue) game.ModifiedOn = null;

            var player = await _context.Players.FindAsync(game.WinningPlayer?.Id);
            if (player == null)
            {
                return new BadRequestObjectResult($"{nameof(game.WinningPlayer)} not found: {game.WinningPlayer?.Id}");
            }

            game.WinningPlayer = player;
            game.WinningPlayerId = player.Id;

            await _context.AddAsync(game);
            await _context.SaveChangesAsync();

            var insertedGame = await _context.Games.FindAsync(game.Id);

            return new OkObjectResult(insertedGame);
        }
    }
}
