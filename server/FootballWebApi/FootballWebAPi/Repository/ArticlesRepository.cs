using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Interfaces;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Repository
{
    public class ArticlesRepository : IArticleRepository
    {

        private FootballWebSiteDbEntities _entities;

        public ArticlesRepository()
        {
            _entities = new FootballWebSiteDbEntities();
        }

        public async Task<IEnumerable<JArticle>> GetArticles()
        {
            var currentSeasonId = _entities.Seasons.Single(o => o.currentSeason).id;

            var articles = await _entities.Articles.Where(o => o.deletedDate.HasValue == false
            && o.ownerId.ToString() == Properties.Settings.Default.OwnerId
            && o.seasonId == currentSeasonId).OrderByDescending(o => o.creationDate).ToListAsync();

            return Mapper.Map(articles);
        }

        public async Task<JArticle> GetArticle(Guid id)
        {
            var article = await _entities.Articles.SingleOrDefaultAsync(o => o.deletedDate.HasValue == false && o.id == id);
            if (article != null)
            {
                return Mapper.Map(article);
            }

            return null;
        }

        public JArticle GetArticlePerGame(Guid gameId)
        {
            var article = _entities.Articles.SingleOrDefault(o => o.gameId == gameId);
            if (article != null)
            {
                return Mapper.Map(article);
            }
            return null;
        }

        public JArticle CreateArticle(JArticle jArticle)
        {
            var currentSeasonId = _entities.Seasons.Single(o => o.currentSeason).id;
            var article = new Article
            {
                id = Guid.NewGuid(),
                creationDate = DateTime.Now,
                publishedDate = jArticle.Published ? DateTime.Now : (DateTime?)null,
                userId = jArticle.UserId,
                title = jArticle.Title,
                body = jArticle.Body,
                gameId = jArticle.GameId,
                ownerId = new Guid(Properties.Settings.Default.OwnerId),
                seasonId = currentSeasonId
            };

            _entities.Articles.Add(article);
            _entities.SaveChanges();
            return jArticle;

        }

        public JArticle SaveArticle(Guid id, JArticle article)
        {
            article.ModifiedDate = DateTime.Now;

            var correspondingArticle = _entities.Articles.Where(o => o.deletedDate.HasValue == false).Single(o => o.id == id);
            correspondingArticle.title = article.Title;
            correspondingArticle.body = article.Body;
            correspondingArticle.gameId = article.GameId;
            correspondingArticle.modifiedDate = article.ModifiedDate;

            if (article.Published && correspondingArticle.publishedDate.HasValue == false)
            {
                //Article newly published
                correspondingArticle.publishedDate = DateTime.Now;
            }
            else if (!article.Published && correspondingArticle.publishedDate.HasValue)
            {
                //unpublish
                correspondingArticle.publishedDate = null;
            }

            _entities.SaveChanges();
            return Mapper.Map(correspondingArticle);
        }

        public void DeleteArticle(Guid id)
        {
            var correspondingArticle = _entities.Articles.Where(o => o.deletedDate.HasValue == false).Single(o => o.id == id);
            correspondingArticle.deletedDate = DateTime.Now;
            _entities.SaveChanges();
        }

        #region Dispose 

        // Flag: Has Dispose already been called?
        bool disposed = false;

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                _entities?.Dispose();
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        ~ArticlesRepository()
        {
            Dispose(false);
        }

        #endregion
    }
}
