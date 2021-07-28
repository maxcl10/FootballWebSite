using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Interfaces
{
    public interface IArticleRepository : IDisposable
    {
        JArticle CreateArticle(Guid ownerId, JArticle jArticle);
        void DeleteArticle(Guid ownerId, Guid id);
        Task<JArticle> GetArticle(Guid ownerId, Guid articleId);
        JArticle GetArticlePerGame(Guid ownerId, Guid gameId);
        Task<IEnumerable<JArticle>> GetArticles(Guid ownerId, bool publishedOnly);
        JArticle UpdateArticle(Guid ownerId, Guid id, JArticle article);
    }
}
