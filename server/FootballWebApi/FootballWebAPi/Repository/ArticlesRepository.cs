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

        public async Task<IEnumerable<JArticle>> GetArticles(Guid ownerId)
        {
            var currentSeasonId = _entities.Seasons.Single(o => o.CurrentSeason).SeasonId;

            var articles = await _entities.Articles.Where(o => o.DeletedDate.HasValue == false
            && o.OwnerId == ownerId
            && o.SeasonId == currentSeasonId).OrderByDescending(o => o.CreationDate).ToListAsync();

            return Mapper.Map(articles);
        }

        public async Task<JArticle> GetArticle(Guid ownerId, Guid articleId)
        {
            var article = await _entities.Articles.SingleOrDefaultAsync(o => o.DeletedDate.HasValue == false && o.ArticleId == articleId && o.OwnerId == ownerId);
            if (article != null)
            {
                return Mapper.Map(article);
            }

            return null;
        }

        public JArticle GetArticlePerGame(Guid ownerId, Guid gameId)
        {
            var article = _entities.Articles.SingleOrDefault(o => o.GameId == gameId && o.OwnerId == ownerId);
            if (article != null)
            {
                return Mapper.Map(article);
            }
            return null;
        }

        public JArticle CreateArticle(Guid ownerId, JArticle jArticle)
        {
            var currentSeasonId = _entities.Seasons.Single(o => o.CurrentSeason).SeasonId;
            jArticle.Id = Guid.NewGuid();

            var article = new Article
            {
                ArticleId = jArticle.Id,
                CreationDate = DateTime.Now,
                PublishedDate = jArticle.Published ? DateTime.Now : (DateTime?)null,
                UserId = jArticle.UserId,
                Title = jArticle.Title,
                Body = jArticle.Body,
                GameId = jArticle.GameId,
                OwnerId = ownerId,
                SeasonId = currentSeasonId,
                SubTitle = jArticle.SubTitle,
                ImageUrl = jArticle.ImageUrl,
                ArticleTypeId = jArticle.Type,
            };

            _entities.Articles.Add(article);
            _entities.SaveChanges();
            return jArticle;

        }

        public JArticle UpdateArticle(Guid ownerId, Guid id, JArticle article)
        {
            article.ModifiedDate = DateTime.Now;

            var correspondingArticle = _entities.Articles.Where(o => o.DeletedDate.HasValue == false).Single(o => o.ArticleId == id && o.OwnerId == ownerId);
            correspondingArticle.Title = article.Title;
            correspondingArticle.Body = article.Body;
            correspondingArticle.GameId = article.GameId;
            correspondingArticle.ModifiedDate = article.ModifiedDate;
            correspondingArticle.ImageUrl = article.ImageUrl;

            if (article.Published && correspondingArticle.PublishedDate.HasValue == false)
            {
                //Article newly published
                correspondingArticle.PublishedDate = DateTime.Now;
            }
            else if (!article.Published && correspondingArticle.PublishedDate.HasValue)
            {
                //unpublish
                correspondingArticle.PublishedDate = null;
            }

            _entities.SaveChanges();
            return Mapper.Map(correspondingArticle);
        }

        public void DeleteArticle(Guid ownerId, Guid id)
        {
            var correspondingArticle = _entities.Articles.Where(o => o.DeletedDate.HasValue == false).Single(o => o.ArticleId == id && o.OwnerId == ownerId);
            correspondingArticle.DeletedDate = DateTime.Now;
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
