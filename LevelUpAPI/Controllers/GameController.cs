using LevelUpAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LevelUpAPI.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private static List<Game> games = new List<Game>();

        [HttpGet]
        public ActionResult<List<Game>> GetGames()
        {
            return Ok(games);
        }

        [HttpGet("{id}")]
        public ActionResult<Game> GetGameById(int id)
        {
            var game = games.FirstOrDefault(g => g.Id == id);
            if (game == null) return NotFound(new { message = "Jogo não encontrado." });
            return Ok(game);
        }

        [HttpPost]
        public ActionResult<Game> CreateGame([FromBody] Game game)
        {
            if (game == null) return BadRequest(new { message = "Dados inválidos." });

            game.Id = games.Count + 1;
            games.Add(game);
            return CreatedAtAction(nameof(GetGameById), new { id = game.Id }, game);
        }
     
        [HttpPut("{id}")]
        public ActionResult UpdateGame(int id, [FromBody] Game updatedGame)
        {
            var game = games.FirstOrDefault(g => g.Id == id);
            if (game == null) return NotFound(new { message = "Jogo não encontrado." });

            game.Title = updatedGame.Title;
            game.Genre = updatedGame.Genre;
            game.ReleaseYear = updatedGame.ReleaseYear;

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialUpdateGame(int id, [FromBody] Game updatedGame)
        {
            var game = games.FirstOrDefault(g => g.Id == id);
            if (game == null) return NotFound(new { message = "Jogo não encontrado." });

            if (!string.IsNullOrEmpty(updatedGame.Title)) game.Title = updatedGame.Title;
            if (!string.IsNullOrEmpty(updatedGame.Genre)) game.Genre = updatedGame.Genre;
            if (updatedGame.ReleaseYear > 0) game.ReleaseYear = updatedGame.ReleaseYear;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteGame(int id)
        {
            var game = games.FirstOrDefault(g => g.Id == id);
            if (game == null) return NotFound(new { message = "Jogo não encontrado." });

            games.Remove(game);
            return NoContent();
        }
    }
}