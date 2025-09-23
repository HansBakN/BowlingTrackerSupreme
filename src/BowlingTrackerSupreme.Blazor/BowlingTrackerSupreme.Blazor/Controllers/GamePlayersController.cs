using BowlingTrackerSupreme.Blazor.DtoModels;
using BowlingTrackerSupreme.Domain.Models;
using BowlingTrackerSupreme.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BowlingTrackerSupreme.Blazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamePlayersController : ControllerBase
    {
        private readonly BowlingTrackerSupremeDbContext _context;

        public GamePlayersController(BowlingTrackerSupremeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var gamePlayers = await _context.GamePlayerSet
                .Include(gp => gp.Player)
                .Include(gp => gp.Game)
                .Include(gp => gp.PlayerNickname)
                .ToListAsync();

            return new OkObjectResult(gamePlayers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var gamePlayer = await _context.GamePlayerSet
                .Include(gp => gp.Player)
                .Include(gp => gp.Game)
                .Include(gp => gp.PlayerNickname)
                .FirstOrDefaultAsync(gp => gp.Id == id);
            if (gamePlayer == null)
            {
                return NotFound();
            }

            return new OkObjectResult(gamePlayer);
        }

        [HttpPost]
        [ApiKeyAuthorize]
        public async Task<IActionResult> Create([FromBody][Required] GamePlayerCreateDto gamePlayer)
        {
            var player = new GamePlayer
            {
                GameId = gamePlayer.GameId,
                PlayerId = gamePlayer.PlayerId,
                PlayerNicknameId = gamePlayer.PlayerNicknameId,
                TotalScore = gamePlayer.TotalScore
            };

            await _context.AddAsync(player);
            await _context.SaveChangesAsync();

            var insertedGamePlayer = await _context.GamePlayerSet.FindAsync(player.Id);
            return new OkObjectResult(insertedGamePlayer);
        }
    }
}
