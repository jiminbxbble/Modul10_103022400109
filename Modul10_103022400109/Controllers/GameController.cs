using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modul10_103022400109.Models;

namespace Modul10_103022400109.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        public static List<Models.Game> games = new List<Models.Game>
        {
            new Game {Id = 1, Name = "Valorant", Developer = "Riot Games", TahunRilis = 2020, Genre = "FPS", Rating = 8.5, Platform = new string[] {"PC"}, Mode = new string[] {"Multiplayer"}, IsOnline = true, Harga = 0},
            new Game {Id = 2, Name = "GTA V", Developer = "Rockstar Games", TahunRilis = 2013, Genre = "Action-Adventure", Rating = 9.5, Platform = new string[] {"PC", "PS4", "PS5", "Xbox"}, Mode = new string[] {"Singleplayer", "Multiplayer"}, IsOnline = true, Harga = 300000},
            new Game {Id = 3, Name = "The Witcher", Developer = "CD Projekt Red", TahunRilis = 2015, Genre = "RPG", Rating = 9.7, Platform = new string[] { "PC", "PS4", "PS5", "Xbox", "Switch"}, Mode = new string[]{"Singleplayer"}, IsOnline = false, Harga = 250000}
        };

        [HttpGet]
        public IEnumerable<Game> Get()
        {
            return games;
        }

        [HttpGet("{id}")]
        public ActionResult<Game> Get(int id)
        {
            var game = games.FirstOrDefault(g => g.Id == id);
            if (game == null)
            {
                return NotFound("Tidak Tersedia");
            }
            return games[id];
        }

        [HttpPost]
        public void Post([FromBody] Game game)
        {
            games.Add(game);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var game = games.FirstOrDefault(g => g.Id == id);
            if (game != null)
            {
                games.Remove(game);
            }
        }
    }
}
