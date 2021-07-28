using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Routing;
using FootballWebSiteApi.Interfaces;
using FootballWebSiteApi.Models;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Repository;


namespace FootballWebSiteApi.Controllers
{
    [RoutePrefix("api/articles")]
    public class ArticlesController : ApiController
    {
        private readonly IArticleRepository _repository;

        public ArticlesController(IArticleRepository articleRepository)
        {
            _repository = articleRepository;
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<JArticle>))]
        public async Task<IHttpActionResult> GetArticles(int count = 25, bool publishedOnly = false)
        {
            var ownerId = Request.Headers.GetOwnerId();
            var articles = await _repository.GetArticles(ownerId, publishedOnly);
            articles = articles.Take(count).ToList();
            return Ok(articles);

        }

        [HttpGet]
        [ResponseType(typeof(JArticle))]
        [Route("{id}")]
        public async Task<IHttpActionResult> GetArticle(Guid id)
        {
            var ownerId = Request.Headers.GetOwnerId();
            var article = await _repository.GetArticle(ownerId, id);

            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        [HttpGet]
        [Route("~/api/games/{gameId}/article")]
        public IHttpActionResult GetGameArticle(Guid gameId)
        {
            var ownerId = Request.Headers.GetOwnerId();
            return Ok(_repository.GetArticlePerGame(ownerId, gameId));
        }



        [HttpPost]
        public IHttpActionResult CreateArticle([FromBody]JArticle article)
        {
            if (ModelState.IsValid)
            {
                var ownerId = Request.Headers.GetOwnerId();
                var retArticle = _repository.CreateArticle(ownerId, article);
                return Ok(retArticle);
            }

            return BadRequest(ModelState);
        }


        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult SaveArticle(Guid id, [FromBody]JArticle article)
        {
            if (ModelState.IsValid)
            {
                var ownerId = Request.Headers.GetOwnerId();
                var retArticle = _repository.UpdateArticle(ownerId, id, article);
                return Ok(retArticle);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteArticle(Guid id)
        {
            var ownerId = Request.Headers.GetOwnerId();
            _repository.DeleteArticle(ownerId, id);
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }
    }
}
