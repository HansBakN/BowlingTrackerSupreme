using BowlingTrackerSupreme.Domain.Models;
using BowlingTrackerSupreme.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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
            var games = await _context.GameSet.ToListAsync();

            return new OkObjectResult(games);
        }

        [HttpPost]
        [ApiKeyAuthorize]
        public async Task<IActionResult> Create([FromBody][Required] Game game)
        {
            if (game.Id.HasValue) game.Id = null;
            if (game.CreatedOn.HasValue) game.CreatedOn = null;
            if (game.ModifiedOn.HasValue) game.ModifiedOn = null;

            await _context.AddAsync(game);
            await _context.SaveChangesAsync();

            var insertedGame = await _context.GameSet.FindAsync(game.Id);

            return new OkObjectResult(insertedGame);
        }
    }
}
