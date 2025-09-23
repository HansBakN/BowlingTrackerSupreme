using BowlingTrackerSupreme.Web.Dtos;
using BowlingTrackerSupreme.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace BowlingTrackerSupreme.Web.Controllers
{
    [ApiController]
    [Route("/players")]
    public class PlayerController(ILogger<PlayerController> logger, IPlayerService playerService) : ControllerBase
    {
        [HttpPost("/")]
        public async Task<ActionResult> Create(CreatePlayerDto dto)
        {
            try
            {
                var createdPlayerId = await playerService.CreatePlayer(dto.Name);

                return Ok(createdPlayerId);
            }
            catch (Exception e)
            {
                logger.LogWarning($"CreatePlayer threw an error: {e.Message}", e);

                return BadRequest();
            }
        }

        [HttpGet("/")]
        public async Task<ActionResult> GetPlayers()
        {
            try
            {
                var players = await playerService.GetAllPlayers();

                return Ok(players);
            }
            catch (Exception e)
            {
                logger.LogWarning($"GetPlayers threw an error: {e.Message}", e);

                return BadRequest();
            }
        }

        [HttpGet("/{id}")]
        public async Task<ActionResult> GetPlayerById(string id)
        {
            try
            {
                if (Guid.TryParse(id, out var playerId))
                {
                    var player = await playerService.GetPlayerById(playerId);

                    return Ok(player);
                }

                return BadRequest("Provided id is invalid format - must be guid");
            }
            catch (Exception e)
            {
                logger.LogWarning($"GetPlayerById threw an error: {e.Message}", e);

                return BadRequest();
            }
        }
    }
}
