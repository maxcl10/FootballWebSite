using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using FootballWebSiteApi.Models;
using FootballWebSiteApi.Repository;

namespace FootballWebSiteApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]
    public class TeamPlayerController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetPlayers(string id)
        {
            using (TeamsRepository repository = new TeamsRepository())
            {
                var teams = repository.GetPlayers(new Guid(id)).ToList();
                return Json(teams);
            }
        }

        [HttpGet]
        public IHttpActionResult GetCurrentPlayers()
        {
            using (PlayerRepository repository = new PlayerRepository())
            {
                var teams = repository.Get(true).ToList();
                return Json(teams);
            }
        }

        [HttpGet]
        public IHttpActionResult GetHomeTeams()
        {
            using (TeamsRepository repository = new TeamsRepository())
            {
                var teams = repository.GetHomeTeams().ToList();
                return Json(teams);
            }
        }

        [HttpPost]
        public IHttpActionResult AddPlayer(TeamPlayer teamPlayer)
        {
            using (TeamsRepository repository = new TeamsRepository())
            {
                repository.AddPlayer(teamPlayer.playerId, teamPlayer.teamId);
                return Json(true);
            }
        }

        [HttpPost]
        public IHttpActionResult RemovePlayer(TeamPlayer teamPlayer)
        {
            using (TeamsRepository repository = new TeamsRepository())
            {
                repository.RemovePlayer(teamPlayer.playerId, teamPlayer.teamId);
                return Json(true);
            }
        }
    }
}
