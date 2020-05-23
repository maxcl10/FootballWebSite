using System;
using System.Collections.Generic;
using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Interfaces
{
    public interface ILazyRankingRepository : IDisposable
    {
        IEnumerable<JRanking> GetRanking(Guid ownerId);
        IEnumerable<JRanking> GetRankingFromUrl(string url);
        IEnumerable<JCompetitionSeason> GetSeasonCompetitions(Guid ownerId);

        void SaveRanking(IEnumerable<LazyRanking> items, Guid competitionSeasonId);

        JCompetitionSeason GetChampionshipData(Guid ownerId);
        void UpdateRanking(Guid ownerId);

    }
}
