using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Routing;
using FootballWebSiteApi.Interfaces;
using FootballWebSiteApi.Models;
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
        public async Task<IHttpActionResult> GetArticles(int count = 25)
        {
            var articles = await _repository.GetArticles();
            articles = articles.Take(count).ToList();
            return Ok(articles);
        }

        [HttpGet]
        [ResponseType(typeof(JArticle))]
        [Route("{id}")]
        public async Task<IHttpActionResult> GetArticle(Guid id)
        {
            var article = await _repository.GetArticle(id);

            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        [HttpGet]
        [Route("game/{gameId}")]
        public IHttpActionResult GetGameArticle(Guid gameId)
        {
            return Ok(_repository.GetArticlePerGame(gameId));
        }



        [HttpPost]
        public IHttpActionResult CreateArticle([FromBody]JArticle article)
        {
            if (ModelState.IsValid)
            {
                var retArticle = _repository.CreateArticle(article);
                return Ok(retArticle);
            }

            return BadRequest(ModelState);
        }


        [HttpPut]
        public IHttpActionResult SaveArticle(Guid id, [FromBody]JArticle article)
        {
            if (ModelState.IsValid)
            {
                var retArticle = _repository.SaveArticle(id, article);
                return Ok(retArticle);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IHttpActionResult DeleteArticle(Guid id)
        {
            _repository.DeleteArticle(id);
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }
    }
}
