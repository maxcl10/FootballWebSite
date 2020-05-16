using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using FootballWebSiteApi.Interfaces;

namespace FootballWebSiteApi.Controllers
{
    [RoutePrefix("api/competitions")]
    public class CompetitionsController : ApiController
    {
        private readonly ILazyRankingRepository _lazyRankingRepository;

        public CompetitionsController(ILazyRankingRepository lazyRankingRepository)
        {
            this._lazyRankingRepository = lazyRankingRepository;
        }

        [HttpGet]
        public IHttpActionResult GetCompetitions()
        {
            var result = _lazyRankingRepository.GetSeasonCompetitions();
            return Ok(result);
        }


    }
}
