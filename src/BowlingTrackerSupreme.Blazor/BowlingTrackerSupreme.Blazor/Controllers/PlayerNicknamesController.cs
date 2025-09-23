using BowlingTrackerSupreme.Blazor.DtoModels;
using BowlingTrackerSupreme.Domain.Models;
using BowlingTrackerSupreme.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BowlingTrackerSupreme.Blazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerNicknamesController : ControllerBase
    {
        private readonly BowlingTrackerSupremeDbContext _context;

        public PlayerNicknamesController(BowlingTrackerSupremeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var nicknames = await _context.PlayerNicknameSet
                .Include(n => n.Player)
                .ToListAsync();

            return new OkObjectResult(nicknames);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var nickname = await _context.PlayerNicknameSet
                .Include(n => n.Player)
                .FirstOrDefaultAsync(n => n.Id == id);
            if (nickname == null)
            {
                return NotFound();
            }
            return new OkObjectResult(nickname);
        }

        [HttpPost]
        [ApiKeyAuthorize]
        public async Task<IActionResult> Create([FromBody] PlayerNicknameCreateDto dto)
        {
            var nickname = new PlayerNickname
            {
                PlayerId = dto.PlayerId,
                Nickname = dto.Nickname
            };

            await _context.AddAsync(nickname);
            await _context.SaveChangesAsync();

            var insertedNickname = await _context.PlayerNicknameSet.FindAsync(nickname.Id);
            return new OkObjectResult(insertedNickname);
        }
    }
}
