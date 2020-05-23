using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Interfaces;
using FootballWebSiteApi.Repository;
using Newtonsoft.Json;

namespace FootballWebSiteApi.Controllers
{
    [RoutePrefix("api/rankings")]
    public class RankingsController
        : ApiController
    {
        private readonly ILazyRankingRepository _lazyRankingRepository;
        private readonly ITeamsRepository _teamsRepository;

        public RankingsController(ILazyRankingRepository lazyRankingRepository, ITeamsRepository teamsRepository)
        {
            this._lazyRankingRepository = lazyRankingRepository;
            this._teamsRepository = teamsRepository;
        }

        public IHttpActionResult Get()
        {
            var ownerId = Request.Headers.GetOwnerId();
            return Ok(_lazyRankingRepository.GetRanking(ownerId).ToList());

        }

        public IHttpActionResult Get(string id)
        {
            var ownerId = Request.Headers.GetOwnerId();
            var team = _teamsRepository.GetHomeTeams(ownerId).Single(o => o.Id.ToString() == id);
            {
                return Ok(_lazyRankingRepository.GetRankingFromUrl(team.RankingUrl).ToList());
            }

        }

        public async Task<IHttpActionResult> Post()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            try
            {
                // Read the form data.
                var files = await Request.Content.ReadAsMultipartAsync();

                // This illustrates how to get the file names.
                var fileContent = await files.Contents[0].ReadAsStringAsync();

                var items = JsonConvert.DeserializeObject<List<LazyRanking>>(fileContent);

                //using (LazyRankingRepository repository = new LazyRankingRepository())
                //{
                //    repository.SaveRanking(items);
                //}

                return Ok(true);
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }

        [Route("~/api/championship")]
        [HttpGet]
        public IHttpActionResult GetChampionshipData()
        {
            var ownerId = Request.Headers.GetOwnerId();
            var data = _lazyRankingRepository.GetChampionshipData(ownerId);
            return Ok(data);
        }


        [Route("~/api/UpdateRankingFromLafa")]
        [HttpGet]
        public IHttpActionResult UpdateRankingFromLafa()
        {
            var ownerId = Request.Headers.GetOwnerId();
            _lazyRankingRepository.UpdateRanking(ownerId);
            return Ok();
        }

        public List<LazyRanking> LoadJson(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                List<LazyRanking> items = JsonConvert.DeserializeObject<List<LazyRanking>>(json);
                return items;
            }
        }

        public IHttpActionResult Put(string id, LazyRanking value)
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult Delete(string id)
        {
            throw new NotImplementedException();
        }


    }
}
