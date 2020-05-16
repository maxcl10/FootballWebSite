using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using FootballWebSiteApi.Interfaces;
using FootballWebSiteApi.Models;
using FootballWebSiteApi.Repository;

namespace FootballWebSiteApi.Controllers
{
    [RoutePrefix("api/games")]
    public class GamesController : ApiController
    {
        private readonly IGamesRepository _gamesRepository;
        private readonly ILgefRepository _lgefRepository;

        public GamesController(IGamesRepository gamesRepository, ILgefRepository lgefRepository)
        {
            this._gamesRepository = gamesRepository;
            this._lgefRepository = lgefRepository;
        }

        [HttpGet]
        public IHttpActionResult GetGames()
        {
            var games = _gamesRepository.GetGames().ToList();
            return Ok(games);
        }

        [HttpGet]
        public IHttpActionResult GetGame(string id)
        {
            var games = _gamesRepository.GetGame(id);
            return Ok(games);
        }


        public IHttpActionResult Post(JGame game)
        {
            if (ModelState.IsValid)
            {
                var retGame = _gamesRepository.CreateGame(game);
                return Created("", retGame);
            }

            return BadRequest(ModelState);

        }

        public IHttpActionResult Put(string id, JGame game)
        {
            if (ModelState.IsValid)
            {
                var retGame = _gamesRepository.SaveGame(id, game);
                return Ok(retGame);
            }

            return BadRequest(ModelState);
        }

        public IHttpActionResult Delete(string id)
        {
            _gamesRepository.DeleteGame(id);
            return Ok(true);
        }


        [Route("lgef")]
        [HttpGet]
        public IHttpActionResult GetChampionshipData()
        {
            var retGames = _lgefRepository.GetGames("https://lgef.fff.fr/recherche-clubs/?scl={0}&tab=resultats&subtab=agenda", 9504);
            return Ok(retGames);
        }

        [Route("next")]
        // GET: api/NextGame
        public IHttpActionResult GetNextGame()
        {
            var nextGame = _gamesRepository.GetNextGame();
            return Ok(nextGame);
        }

        [Route("previous")]
        public IHttpActionResult GetPreviousGame()
        {
            var nextGame = _gamesRepository.GetPreviousGame();
            return Ok(nextGame);
        }

    }
}
