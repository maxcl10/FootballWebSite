using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballWebSiteApi.Repository
{
    public class ArticleRepository : IDatabaseRepository<JArticle>, IDisposable
    {

        private FootballWebSiteDbEntities entities;

        public ArticleRepository()
        {
            entities = new FootballWebSiteDbEntities();
        }
        public IEnumerable<JArticle> Get()
        {
            var currentSeasonId = entities.Seasons.Single(o => o.currentSeason).id;

            var articles = entities.Articles.Where(o => o.deletedDate.HasValue == false
            && o.ownerId.ToString() == Properties.Settings.Default.OwnerId
            && o.seasonId == currentSeasonId).OrderByDescending(o => o.creationDate);

            return Mapper.Map(articles);
        }

        public JArticle Get(string id)
        {
            return Mapper.Map(entities.Articles.Where(o => o.deletedDate.HasValue == false).Single(o => o.id.ToString() == id));
        }

        public JArticle GetArticlePerGame(Guid gameId)
        {
            var article = entities.Articles.SingleOrDefault(o => o.gameId == gameId);
            if (article != null)
            {
                return Mapper.Map(article);
            }
            return null;
        }

        public JArticle Post(JArticle jArticle)
        {
            var currentSeasonId = entities.Seasons.Single(o => o.currentSeason).id;
            var article = new Article
            {
                id = Guid.NewGuid(),
                creationDate = DateTime.Now,
                publishedDate = jArticle.published ? DateTime.Now : (DateTime?)null,
                userId = jArticle.userId,
                title = jArticle.title,
                body = jArticle.body,
                gameId = jArticle.gameId,
                ownerId = new Guid(Properties.Settings.Default.OwnerId),
                seasonId = currentSeasonId
        };

            entities.Articles.Add(article);
            entities.SaveChanges();
            return jArticle;

        }

        public JArticle Put(string id, JArticle article)
        {
            article.modifiedDate = DateTime.Now;

            var correspondingArticle = entities.Articles.Where(o => o.deletedDate.HasValue == false).Single(o => o.id.ToString() == id);
            correspondingArticle.title = article.title;
            correspondingArticle.body = article.body;
            correspondingArticle.gameId = article.gameId;
            correspondingArticle.modifiedDate = article.modifiedDate;

            if (article.published && correspondingArticle.publishedDate.HasValue == false)
            {
                //Article newly published
                correspondingArticle.publishedDate = DateTime.Now;
            }
            else if (!article.published && correspondingArticle.publishedDate.HasValue)
            {
                //unpublish
                correspondingArticle.publishedDate = null;
            }

            entities.SaveChanges();
            return Mapper.Map(correspondingArticle);
        }

        public void Delete(string id)
        {
            var correspondingArticle = entities.Articles.Where(o => o.deletedDate.HasValue == false).Single(o => o.id.ToString() == id);
            correspondingArticle.deletedDate = DateTime.Now;
            entities.SaveChanges();
        }

        public void Dispose()
        {
            entities.Dispose();
        }
    }
}
