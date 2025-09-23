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
    public class FramesController : ControllerBase
    {
        private readonly BowlingTrackerSupremeDbContext _context;

        public FramesController(BowlingTrackerSupremeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var frames = await _context.FrameSet
                .Include(f => f.GamePlayer)
                .ToListAsync();
            return new OkObjectResult(frames);
        }

        [HttpPost]
        [ApiKeyAuthorize]
        public async Task<IActionResult> Create([FromBody][Required] FrameCreateDto dto)
        {
            var frame = new Frame
            {
                GamePlayerId = dto.GamePlayerId,
                Index = dto.Index,
                FirstRoll = dto.FirstRoll,
                SecondRoll = dto.SecondRoll,
                ThirdRoll = dto.ThirdRoll,
                Score = dto.FirstRoll + dto.SecondRoll + dto.ThirdRoll.GetValueOrDefault(0),
            };

            if (dto.Index < 1 || dto.Index > 10)
            {
                return BadRequest("Frame index must be between 1 and 10.");
            }

            var existingIndexes = _context.FrameSet
                .Where(f => f.GamePlayerId == dto.GamePlayerId)
                .Select(f => f.Index);
            if (existingIndexes.Contains(dto.Index))
            {
                return BadRequest($"A frame with index {dto.Index} already exists for this game player.");
            }

            await _context.AddAsync(frame);
            await _context.SaveChangesAsync();

            var insertedFrame = await _context.FrameSet.FindAsync(frame.Id);
            return new OkObjectResult(insertedFrame);
        }
    }
}
