using FootballWebSiteApi.Models;
using FootballWebSiteApi.Repository;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FootballWebSiteApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]
    public class GamesPlayersController : ApiController
    {
        // GET: api/games/ec84f223-a489-473a-9fb1-57ee6f610688/players
        public IHttpActionResult Get(Guid gameId)
        {
            using (PlayerRepository repository = new PlayerRepository())
            {
                var players = repository.GetGamePlayers(gameId);
                return Json(players);
            }
        }


        // POST: api/GamesPlayers
        public IHttpActionResult Post(Guid gameId, [FromBody] JGamePlayer player)
        {
            using (PlayerRepository repository = new PlayerRepository())
            {
                var retPlayer = repository.AddGamePlayer(gameId, player);
                return Created<JGamePlayer>(Request.RequestUri + retPlayer.id.ToString(), retPlayer);
            }
        }

        public IHttpActionResult Put(Guid gameId, Guid id, [FromBody] JGamePlayer player)
        {
            using (PlayerRepository repository = new PlayerRepository())
            {
                repository.EditGamePlayer(gameId, id, player);
                return Ok();
            }
        }


        // DELETE: api/GamesPlayers/5
        public IHttpActionResult Delete(Guid gameId, Guid id)
        {
            using (PlayerRepository repository = new PlayerRepository())
            {
                repository.DeleteGamePlayer(gameId, id);
                return Ok();
            }
        }
    }
}
