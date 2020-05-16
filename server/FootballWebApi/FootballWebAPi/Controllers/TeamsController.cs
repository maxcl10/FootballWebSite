using System;
using System.Linq;
using System.Web.Http;
using FootballWebSiteApi.Interfaces;
using FootballWebSiteApi.Models;


namespace FootballWebSiteApi.Controllers
{
    [RoutePrefix("api/teams")]
    public class TeamsController : ApiController
    {
        private readonly ITeamsRepository _teamsRepository;

        public TeamsController(ITeamsRepository teamsRepository)
        {
            this._teamsRepository = teamsRepository;
        }

        [HttpGet]
        public IHttpActionResult GetTeams()
        {
            var teams = _teamsRepository.GetTeams().ToList();
            return Ok(teams);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetTeam(string id)
        {
            var team = _teamsRepository.Get(id);
            return Ok(team);

        }

        [HttpGet]
        [Route("home")]
        public IHttpActionResult GetHomeTeams()
        {
            var teams = _teamsRepository.GetHomeTeams().ToList();
            return Ok(teams);
        }



        [HttpGet]
        [Route("{id}/players")]
        public IHttpActionResult GetTeamPlayers(Guid id)
        {
            var teams = _teamsRepository.GetPlayers(id).ToList();
            return Ok(teams);
        }

        [HttpPost]
        public IHttpActionResult CreateTeam([FromBody] JTeam team)
        {
            if (ModelState.IsValid)
            {

                var retTeam = _teamsRepository.Post(team);
                return Ok(retTeam);

            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IHttpActionResult Put(string id, [FromBody] JTeam team)
        {
            if (ModelState.IsValid)
            {


                var retTeam = _teamsRepository.Put(id, team);
                return Ok(retTeam);

            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("players")]
        public IHttpActionResult AddPlayer(TeamPlayer teamPlayer)
        {
            _teamsRepository.AddPlayer(teamPlayer.PlayerId, teamPlayer.TeamId);
            return Ok(true);
        }


        [HttpDelete]
        [Route("players")]
        public IHttpActionResult RemovePlayer(TeamPlayer teamPlayer)
        {
            _teamsRepository.RemovePlayer(teamPlayer.PlayerId, teamPlayer.TeamId);
            return Ok(true);

        }

        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            _teamsRepository.Delete(id);
            return Ok(true);
        }

        protected override void Dispose(bool disposing)
        {
            _teamsRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
