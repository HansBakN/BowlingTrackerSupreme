using BowlingTrackerSupreme.Domain.Models;
using BowlingTrackerSupreme.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BowlingTrackerSupreme.Blazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly BowlingTrackerSupremeDbContext _context;

        public PlayersController(BowlingTrackerSupremeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var players = await _context.PlayerSet.ToListAsync();

            return new OkObjectResult(players);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Player player)
        {
            //if (player.Id.HasValue)         player.Id = null;
            //if (player.CreatedOn.HasValue)  player.CreatedOn = null;
            //if (player.ModifiedOn.HasValue) player.ModifiedOn = null;

            await _context.AddAsync(player);
            await _context.SaveChangesAsync();

            var insertedPlayer = await _context.PlayerSet.FindAsync(player.Id);
            return new OkObjectResult(insertedPlayer);
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] Player player)
        {

            //var existingPlayer = await _context.PlayerSet.FindAsync(player.Id);
            //if (existingPlayer == null)
            //{
            //    return new BadRequestObjectResult($"Unable to find {player.Id} player");
            //}

            _context.Update(player);
            await _context.SaveChangesAsync();

            var updatedPlayer = await _context.PlayerSet.FindAsync(player.Id);
            return new OkObjectResult(updatedPlayer);
        }
    }
}
