using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using FootballWebSiteApi.Models;
using FootballWebSiteApi.Repository;

namespace FootballWebSiteApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]
    public class TeamsController : ApiController, ICrudApi<JTeam>
    {
        public IHttpActionResult Get()
        {
            using (IDatabaseRepository<JTeam> repository = new TeamsRepository())
            {
                var teams = repository.Get().ToList();
                return Json(teams);
            }
        }


        public IHttpActionResult Get(string id)
        {
            using (IDatabaseRepository<JTeam> repository = new TeamsRepository())
            {
                var team = repository.Get(id);
                return Json(team);
            }
        }

        public IHttpActionResult Post([FromBody] JTeam team)
        {
            if (ModelState.IsValid)
            {
                using (IDatabaseRepository<JTeam> repository = new TeamsRepository())
                {
                    var retTeam = repository.Post(team);
                    return Json(retTeam);
                }
            }
            return null;
        }

        public IHttpActionResult Put(string id, [FromBody] JTeam team)
        {
            if (ModelState.IsValid)
            {
                using (IDatabaseRepository<JTeam> repository = new TeamsRepository())
                {

                    var retTeam = repository.Put(id, team);
                    return Json(retTeam);
                }
            }
            return null;
        }

        public IHttpActionResult Delete(string id)
        {
            using (IDatabaseRepository<JTeam> repository = new TeamsRepository())
            {
                repository.Delete(id);
                return Json(true);
            }
        }}
}
