using FootballWebSiteApi.Models;
using FootballWebSiteApi.Repository;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FootballWebSiteApi.Controllers
{


    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]

    public class CompetitionsController : ApiController
    {
        // GET: api/Articles
        public IHttpActionResult Get()
        {
            using (CompetitionsRepository repo = new CompetitionsRepository())
            {
                return Ok(repo.Get());
            }

        }


        [Route("api/competitions/{competitionId}/add/{teamId}")]
        [HttpPost]
        public IHttpActionResult AddTeamToCompetition(Guid competitionId, Guid teamId)
        {
            using (CompetitionsRepository repository = new CompetitionsRepository())
            {
                repository.AddTeamToCompetition(teamId, competitionId);
                return Ok();
            }


        }
        //    public IHttpActionResult GetGameArticle(Guid gameId)
        //    {
        //        using (ArticleRepository repository = new ArticleRepository())
        //        {
        //            return Json(repository.GetArticlePerGame(gameId));
        //        }
        //    }

        //    // GET: api/Articles/5
        //    public IHttpActionResult Get(string id)
        //    {
        //        using (IDatabaseRepository<JArticle> repository = new ArticleRepository())
        //        {
        //            var article = repository.Get(id);
        //            return Json(article);
        //        }
        //    }

        //    // POST: api/Articles
        //    public IHttpActionResult Post([FromBody]JArticle article)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            using (IDatabaseRepository<JArticle> repository = new ArticleRepository())
        //            {
        //                var retArticle = repository.Post(article);
        //                return Json(retArticle);
        //            }
        //        }
        //        return null;
        //    }


        //    // PUT: api/Articles/5
        //    public IHttpActionResult Put(string id, [FromBody]JArticle article)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            using (IDatabaseRepository<JArticle> repository = new ArticleRepository())
        //            {

        //                var retArticle = repository.Put(id, article);
        //                return Json(retArticle);
        //            }
        //        }
        //        return null;
        //    }

        //    // DELETE: api/Articles/5
        //    public IHttpActionResult Delete(string id)
        //    {
        //        using (IDatabaseRepository<JArticle> repository = new ArticleRepository())
        //        {
        //            repository.Delete(id);
        //            return Json(true);
        //        }
        //    }
        //}
    }
}
