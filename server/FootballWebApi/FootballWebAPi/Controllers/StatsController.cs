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
    [RoutePrefix("api/stats")]
    public class StatsController : ApiController
    {
        private readonly IStatsRepository _statsRepository;

        public StatsController(IStatsRepository statsRepository)
        {
            _statsRepository = statsRepository;
        }

        [HttpGet]
        [Route("shape")]
        public IHttpActionResult GetShape()
        {
            var ownerId = Request.Headers.GetOwnerId();
            var res = _statsRepository.GetShape(ownerId);
            return Ok(res);
        }

        [HttpGet]
        [Route("players")]
        public IHttpActionResult GetPlayersStats()
        {
            var ownerId = Request.Headers.GetOwnerId();
            var strikers = _statsRepository.GetPlayersStats(ownerId).Where(o => o.TotalGames.HasValue && o.TotalGames.Value > 0).OrderByDescending(o => o.TotalGoals).ThenByDescending(o => o.ChampionshipGoals);
            return Ok(strikers);
        }

        [HttpGet]
        [Route("players/{playerId}")]
        public IHttpActionResult GetPlayerStats(Guid playerId)
        {
            var ownerId = Request.Headers.GetOwnerId();
            var stricker = _statsRepository.GetPlayerStats(ownerId, playerId);
            return Ok(stricker);
        }


        [HttpGet]
        [Route("team/players")]
        public IHttpActionResult GetTeamStats()
        {
            var ownerId = Request.Headers.GetOwnerId();
            var strickers = _statsRepository.GetPlayersStats(ownerId).OrderByDescending(o => o.TotalGoals).ThenByDescending(o => o.ChampionshipGoals);
            return Ok(strickers);
        }

        [HttpGet]
        [Route("scoredPerGame")]
        public IHttpActionResult GetScoredGoalsPerGame()
        {
            var ownerId = Request.Headers.GetOwnerId();
            var scored = _statsRepository.ScoredGoalPerGame(ownerId);
            return Ok(scored);
        }

        [HttpGet]
        [Route("concededPerGame")]
        public IHttpActionResult GetConcededGoalsPerGame()
        {
            var ownerId = Request.Headers.GetOwnerId();
            var scored = _statsRepository.ConcededGoalPerGame(ownerId);
            return Ok(scored);
        }

        //[HttpGet]
        //[Route("strickerOld")]
        //public IHttpActionResult GetStrickers()
        //{
        //    using (StatsRepository repository = new StatsRepository())
        //    {
        //        var strikers = repository.GetStrikers().Where(o => o.TotalGoals.HasValue && o.TotalGoals.Value > 0).OrderByDescending(o => o.TotalGoals).ThenByDescending(o => o.ChampionshipGoals);
        //        return Ok(strikers);
        //    }
        //}

        //[HttpGet]
        //[Route("team/strickerOld")]
        //public IHttpActionResult GetTeamStrickers()
        //{
        //    using (StatsRepository repository = new StatsRepository())
        //    {
        //        var strickers = repository.GetStrikers().OrderByDescending(o => o.TotalGoals).ThenByDescending(o => o.ChampionshipGoals);
        //        return Ok(strickers);
        //    }
        //}

        //[HttpPost]
        //public IHttpActionResult SetStricker([FromBody]JStricker stricker)
        //{
        //    using (StatsRepository repository = new StatsRepository())
        //    {
        //        repository.SetStricker(stricker);
        //        return Ok(true);
        //    }
        //}

        //[HttpGet]
        ////[Route("api/Stats")]
        //public IHttpActionResult GetRankingHistory()
        //{
        //    using (StatsRepository repository = new StatsRepository())
        //    {
        //        var articles = repository.GetRankingHistory();
        //        return Ok(articles);
        //    }
        //}
    }
}
