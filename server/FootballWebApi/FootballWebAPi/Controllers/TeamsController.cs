using System;
using System.Linq;
using System.Web.Http;
using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Helpers;
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
        public IHttpActionResult GetTeam(Guid id)
        {
            var team = _teamsRepository.Get(id);
            return Ok(team);

        }

        [HttpGet]
        [Route("home")]
        public IHttpActionResult GetHomeTeams()
        {
            var ownerId = Request.Headers.GetOwnerId();
            var teams = _teamsRepository.GetHomeTeams(ownerId).ToList();
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
        public IHttpActionResult Put(Guid id, [FromBody] JTeam team)
        {
            if (ModelState.IsValid)
            {


                var retTeam = _teamsRepository.Put(id, team);
                return Ok(retTeam);

            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("{teamId}/players/{playerId}")]
        public IHttpActionResult AddPlayer(Guid teamId, Guid playerId)
        {
            _teamsRepository.AddPlayer(playerId, teamId);
            return Ok(true);
        }


        [HttpDelete]
        [Route("{teamId}/players/{playerId}")]
        public IHttpActionResult RemovePlayer(Guid teamId, Guid playerId)
        {
            _teamsRepository.RemovePlayer(playerId, teamId);
            return Ok(true);

        }

        [HttpGet]
        [Route("{id}/players")]
        public IHttpActionResult GetTeamPlayers(Guid id)
        {
            var ownerId = Request.Headers.GetOwnerId();
            var teams = _teamsRepository.GetPlayers(ownerId, id).ToList();
            return Ok(teams);
        }

        [HttpDelete]
        public IHttpActionResult Delete(Guid id)
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
