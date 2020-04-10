using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Models;
using FootballWebSiteApi.Repository;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FootballWebSiteApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]
    public class PlayersController : ApiController, ICrudApi<Player>
    {
        // GET: api/Players
        public IHttpActionResult Get()
        {
            using (PlayerRepository repository = new PlayerRepository())
            {
                var players = repository.Get().ToList();
                return Json(players);
            }
        }


        // GET: api/Players/5
        public IHttpActionResult Get(string id)
        {
            using (PlayerRepository repository = new PlayerRepository())
            {
                if (id == "current")
                {
                    var players = repository.Get(true).ToList();
                    return Json(players);
                }
                var player = repository.Get(id);
                return Json(player);
            }
        }

        // POST: api/Players
        public IHttpActionResult Post([FromBody]Player player)
        {
            if (ModelState.IsValid)
            {
                using (PlayerRepository repository = new PlayerRepository())
                {
                    var retPlayer = repository.Post(player);
                    return Json(retPlayer);
                }
            }
            return null;
        }

        // PUT: api/Players/5
        public IHttpActionResult Put(string id, [FromBody]Player player)
        {
            if (ModelState.IsValid)
            {
                using (PlayerRepository repository = new PlayerRepository())
                {

                    var retPlayer = repository.Put(id, player);
                    return Json(retPlayer);
                }
            }
            return null;
        }

        // DELETE: api/Players/5
        public IHttpActionResult Delete(string id)
        {
            using (PlayerRepository repository = new PlayerRepository())
            {
                repository.Delete(id);
                return Json(true);
            }
        }




    }
}
