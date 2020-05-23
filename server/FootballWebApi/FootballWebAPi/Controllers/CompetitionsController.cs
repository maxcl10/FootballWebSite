using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using FootballWebSiteApi.Helpers;
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
            var ownerId = Request.Headers.GetOwnerId();
            var result = _lazyRankingRepository.GetSeasonCompetitions(ownerId);
            return Ok(result);
        }


    }
}
