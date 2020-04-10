using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FootballWebSiteApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]
    public class RankingController : ApiController
    {
        public IHttpActionResult Get()
        {
            using (LazyRankingRepository repository = new LazyRankingRepository())
            {          
               
                return Json(repository.Get().ToList());
            }
        }

        public IHttpActionResult Get(string id)
        {
            using (TeamsRepository teamRepository = new TeamsRepository())
            {
                var team = teamRepository.GetHomeTeams().Single(o => o.id.ToString() == id);
                {
                    using (LazyRankingRepository repository = new LazyRankingRepository())
                    {
                        return Json(repository.Get(team.rankingUrl).ToList());
                    }
                }
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

                return Json(true);
            }
            catch (Exception e)
            {
                return Json(e);
            }
        }

        [Route("api/championship")]
        [HttpGet]
        public IHttpActionResult GetChampionshipData()
        {
            using (LazyRankingRepository repository = new LazyRankingRepository())
            {
               var data = repository.GetChampionshipData();
                return Ok(data);
            }

           
        }




        [Route("api/UpdateRankingFromLafa")]
        [HttpGet]
        public IHttpActionResult UpdateRankingFromLafa()
        {
            using (LazyRankingRepository repository = new LazyRankingRepository())
            {
                repository.UpdateRanking();
            }

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
