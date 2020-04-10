using FootballWebSiteApi.Models;
using FootballWebSiteApi.Repository;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FootballWebSiteApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]
    public class StatsController : ApiController
    {
        [HttpGet]
        //[Route("api/Stats")]
        public IHttpActionResult GetShape()
        {
            using (StatsRepository repository = new StatsRepository())
            {
                var articles = repository.GetShape();
                return Json(articles);
            }
        }

        [HttpGet]
        public IHttpActionResult GetStrickers()
        {
            using (StatsRepository repository = new StatsRepository())
            {
                var strikers = repository.GetStrikers().Where(o => o.totalGoals.HasValue && o.totalGoals.Value > 0).OrderByDescending(o => o.totalGoals).ThenByDescending(o => o.championshipGoals);
                return Json(strikers);
            }
        }

        public IHttpActionResult GetStrickers2()
        {
            using (StatsRepository repository = new StatsRepository())
            {
                var strikers = repository.GetStrikers2().Where(o => o.totalGames.HasValue && o.totalGames.Value > 0).OrderByDescending(o => o.totalGoals).ThenByDescending(o => o.championshipGoals);
                return Json(strikers);
            }
        }




        [HttpGet]
        public IHttpActionResult GetStricker(Guid id)
        {
            using (StatsRepository repository = new StatsRepository())
            {
                var stricker = repository.GetPlayerStats(id);
                return Json(stricker);
            }
        }

        [HttpGet]
        public IHttpActionResult GetTeamStrickers()
        {
            using (StatsRepository repository = new StatsRepository())
            {
                var strickers = repository.GetStrikers().OrderByDescending(o => o.totalGoals).ThenByDescending(o => o.championshipGoals);
                return Json(strickers);
            }
        }

        public IHttpActionResult GetTeamStrickers2()
        {
            using (StatsRepository repository = new StatsRepository())
            {
                var strickers = repository.GetStrikers2().OrderByDescending(o => o.totalGoals).ThenByDescending(o => o.championshipGoals);
                return Json(strickers);
            }
        }

        [HttpGet]
        public IHttpActionResult GetScoredGoalsPerGame()
        {
            using (StatsRepository repository = new StatsRepository())
            {
                var scored = repository.ScoredGoalPerGame();
                return Json(scored);
            }
        }

        [HttpGet]
        public IHttpActionResult GetConcededGoalsPerGame()
        {
            using (StatsRepository repository = new StatsRepository())
            {
                var scored = repository.ConcededGoalPerGame();
                return Json(scored);
            }
        }



        [HttpPost]
        public IHttpActionResult SetStricker([FromBody]JStricker stricker)
        {
            using (StatsRepository repository = new StatsRepository())
            {
                repository.SetStricker(stricker);
                return Json(true);
            }
        }

        [HttpGet]
        //[Route("api/Stats")]
        public IHttpActionResult GetRankingHistory()
        {
            using (StatsRepository repository = new StatsRepository())
            {
                var articles = repository.GetRankingHistory();
                return Json(articles);
            }
        }
    }
}
