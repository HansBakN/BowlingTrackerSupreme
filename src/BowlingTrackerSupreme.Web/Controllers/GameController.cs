using BowlingTrackerSupreme.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace BowlingTrackerSupreme.Web.Controllers
{
    [ApiController]
    [Route("/games")]
    public class GameController(ILogger<GameController> logger, IGameService gameService) : ControllerBase
    {
        [HttpGet("/")]
        public async Task<ActionResult> GetGames()
        {
            try
            {
                var games = await gameService.GetGames();

                return Ok(games);
            }
            catch (Exception e)
            {
                logger.LogWarning($"GetGames threw an error: {e.Message}", e);
                
                return BadRequest();
            }
        }
    }
}
