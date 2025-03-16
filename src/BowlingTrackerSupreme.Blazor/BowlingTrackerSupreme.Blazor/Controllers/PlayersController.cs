using BowlingTrackerSupreme.Domain.Models;
using BowlingTrackerSupreme.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

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
            var players = await _context.Players.ToListAsync();

            return new OkObjectResult(players);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody][Required] Player player)
        {
            if (player.Id.HasValue)         player.Id = null;
            if (player.CreatedOn.HasValue)  player.CreatedOn = null;
            if (player.ModifiedOn.HasValue) player.ModifiedOn = null;

            await _context.AddAsync(player);
            await _context.SaveChangesAsync();

            var insertedPlayer = await _context.Players.FindAsync(player.Id);
            return new OkObjectResult(insertedPlayer);
        }
    }
}
