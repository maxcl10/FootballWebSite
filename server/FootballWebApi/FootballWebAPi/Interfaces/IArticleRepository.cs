using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Interfaces
{
    public interface IArticleRepository : IDisposable
    {
        JArticle CreateArticle(JArticle jArticle);
        void DeleteArticle(Guid id);
        Task<JArticle> GetArticle(Guid id);
        JArticle GetArticlePerGame(Guid gameId);
        Task<IEnumerable<JArticle>> GetArticles();
        JArticle SaveArticle(Guid id, JArticle article);
    }
}
