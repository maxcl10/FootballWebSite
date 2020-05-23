using System;
using System.Web.Http;
using System.Web.Http.Cors;
using FootballWebSiteApi.Interfaces;
using FootballWebSiteApi.Models;
using FootballWebSiteApi.Repository;

namespace FootballWebSiteApi.Controllers
{
    [RoutePrefix("api/gamesPlayers")]
    public class GamesPlayersController : ApiController
    {
        private readonly IPlayersRepository _playersRepository;

        public GamesPlayersController(IPlayersRepository playersRepository)
        {
            this._playersRepository = playersRepository;
        }

        // GET: api/games/ec84f223-a489-473a-9fb1-57ee6f610688/players
        [Route("~/api/games/{gameId}/players")]
        public IHttpActionResult Get(Guid gameId)
        {
            var players = _playersRepository.GetGamePlayers(gameId);
            return Ok(players);
        }


        [Route("~/api/games/{gameId}/players")]
        // POST: api/GamesPlayers
        public IHttpActionResult Post(Guid gameId, [FromBody] JGamePlayer player)
        {

            var retPlayer = _playersRepository.AddGamePlayer(gameId, player);
            return Created<JGamePlayer>(Request.RequestUri + retPlayer.Id.ToString(), retPlayer);

        }

        public IHttpActionResult Put(Guid gameId, Guid id, [FromBody] JGamePlayer player)
        {

            _playersRepository.UpdateGamePlayer(gameId, id, player);
            return Ok();

        }

        [Route("~/api/games/{gameId}/player/{playerId}")]
        // DELETE: api/GamesPlayers/5
        public IHttpActionResult Delete(Guid gameId, Guid playerId)
        {

            _playersRepository.DeleteGamePlayer(gameId, playerId);
            return Ok();

        }
    }
}
