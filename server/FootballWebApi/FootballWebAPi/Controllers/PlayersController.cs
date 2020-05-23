using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Interfaces;
using FootballWebSiteApi.Models;
using FootballWebSiteApi.Repository;

namespace FootballWebSiteApi.Controllers
{
    [RoutePrefix("api/players")]
    public class PlayersController : ApiController
    {
        private readonly IPlayersRepository _playersRepository;

        public PlayersController(IPlayersRepository playersRepository)
        {
            _playersRepository = playersRepository;
        }

        // GET: api/Players
        public IHttpActionResult GetPlayers()
        {
            var ownerId = Request.Headers.GetOwnerId();
            var players = _playersRepository.GetPlayers(ownerId).ToList();
            return Ok(players);
        }

        [HttpGet]
        [Route("current")]
        public IHttpActionResult GetCurrentPlayers()
        {
            var ownerId = Request.Headers.GetOwnerId();
            var players = _playersRepository.GetPlayers(ownerId, true).ToList();
            return Ok(players);
        }



        // GET: api/Players/5
        public IHttpActionResult GetPlayer(Guid id)
        {
            var player = _playersRepository.GetPlayer(id);
            return Ok(player);
        }

        // POST: api/Players
        public IHttpActionResult Post([FromBody]Player player)
        {
            if (ModelState.IsValid)
            {
                var retPlayer = _playersRepository.CreatePlayer(player);
                return Ok(retPlayer);

            }
            return Ok(ModelState);
        }

        // PUT: api/Players/5
        public IHttpActionResult Put(Guid id, [FromBody]Player player)
        {
            if (ModelState.IsValid)
            {
                var retPlayer = _playersRepository.UpdatePlayer(id, player);
                return Ok(retPlayer);
            }

            return Ok(ModelState);
        }

        // DELETE: api/Players/5
        public IHttpActionResult Delete(Guid id)
        {

            _playersRepository.DeletePlayer(id);
            return Ok(true);

        }




    }
}
