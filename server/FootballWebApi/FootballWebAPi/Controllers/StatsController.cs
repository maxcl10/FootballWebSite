using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
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
            var res = _statsRepository.GetShape();
            return Ok(res);
        }

        [HttpGet]
        [Route("strickers")]
        public IHttpActionResult GetStrickers2()
        {
            var strikers = _statsRepository.GetStrikers2().Where(o => o.TotalGames.HasValue && o.TotalGames.Value > 0).OrderByDescending(o => o.TotalGoals).ThenByDescending(o => o.ChampionshipGoals);
            return Ok(strikers);
        }

        [HttpGet]
        [Route("shape/{id}")]
        public IHttpActionResult GetStricker(Guid id)
        {
            var stricker = _statsRepository.GetPlayerStats(id);
            return Ok(stricker);
        }


        [HttpGet]
        [Route("team/strickers")]
        public IHttpActionResult GetTeamStrickers2()
        {
            var strickers = _statsRepository.GetStrikers2().OrderByDescending(o => o.TotalGoals).ThenByDescending(o => o.ChampionshipGoals);
            return Ok(strickers);
        }

        [HttpGet]
        [Route("scoredPerGame")]
        public IHttpActionResult GetScoredGoalsPerGame()
        {
            var scored = _statsRepository.ScoredGoalPerGame();
            return Ok(scored);
        }

        [HttpGet]
        [Route("concededPerGame")]
        public IHttpActionResult GetConcededGoalsPerGame()
        {
            var scored = _statsRepository.ConcededGoalPerGame();
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
