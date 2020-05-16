using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using FootballWebSiteApi.Entities;
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
            var players = _playersRepository.GetPlayers().ToList();
            return Ok(players);
        }

        [HttpGet]
        [Route("current")]
        public IHttpActionResult GetCurrentPlayers()
        {
            var players = _playersRepository.GetPlayers(true).ToList();
            return Ok(players);
        }



        // GET: api/Players/5
        public IHttpActionResult GetPlayer(string id)
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
        public IHttpActionResult Put(string id, [FromBody]Player player)
        {
            if (ModelState.IsValid)
            {
                var retPlayer = _playersRepository.UpdatePlayer(id, player);
                return Ok(retPlayer);
            }

            return Ok(ModelState);
        }

        // DELETE: api/Players/5
        public IHttpActionResult Delete(string id)
        {

            _playersRepository.DeletePlayer(id);
            return Ok(true);

        }




    }
}
