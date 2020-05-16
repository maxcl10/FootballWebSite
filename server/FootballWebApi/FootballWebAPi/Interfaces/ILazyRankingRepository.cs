using System;
using System.Collections.Generic;
using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Interfaces
{
    public interface ILazyRankingRepository : IDisposable
    {
        void Delete(string id);
        IEnumerable<JRanking> Get();
        IEnumerable<JRanking> Get(string url);
        IEnumerable<JCompetitionSeason> GetSeasonCompetitions();
        JCompetitionSeason GetChampionshipData();
        JRanking Post(JRanking value);
        JRanking Post(LazyRanking value);
        JRanking Put(string id, JRanking value);
        JRanking Put(string id, LazyRanking value);
        void SaveRanking(IEnumerable<LazyRanking> items, Guid competitionSeasonId);
        void UpdateRanking();
    }
}
