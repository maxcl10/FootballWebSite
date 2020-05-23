using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using FootballWebSiteApi.Helpers;
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
            var ownerId = Request.Headers.GetOwnerId();
            var games = _gamesRepository.GetGames(ownerId).ToList();
            return Ok(games);
        }


        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetGame(Guid id)
        {
            var ownerId = Request.Headers.GetOwnerId();
            var games = _gamesRepository.GetGame(ownerId, id);
            return Ok(games);
        }


        public IHttpActionResult Post(JGame game)
        {
            var ownerId = Request.Headers.GetOwnerId();
            if (ModelState.IsValid)
            {
                var retGame = _gamesRepository.CreateGame(ownerId, game);
                return Created("", retGame);
            }

            return BadRequest(ModelState);

        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Put(Guid id, JGame game)
        {
            var ownerId = Request.Headers.GetOwnerId();
            if (ModelState.IsValid)
            {
                var retGame = _gamesRepository.SaveGame(ownerId, id, game);
                return Ok(retGame);
            }

            return BadRequest(ModelState);
        }

        public IHttpActionResult Delete(Guid id)
        {
            var ownerId = Request.Headers.GetOwnerId();
            _gamesRepository.DeleteGame(ownerId, id);
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
            var ownerId = Request.Headers.GetOwnerId();
            var nextGame = _gamesRepository.GetNextGame(ownerId);
            return Ok(nextGame);
        }

        [Route("previous")]
        public IHttpActionResult GetPreviousGame()
        {
            var ownerId = Request.Headers.GetOwnerId();
            var nextGame = _gamesRepository.GetPreviousGame(ownerId);
            return Ok(nextGame);
        }

    }
}
