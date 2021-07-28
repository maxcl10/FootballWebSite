using System;
using System.Collections.Generic;
using System.Linq;
using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Interfaces;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Repository
{
    public class LazyRankingRepository : ILazyRankingRepository
    {
        FootballWebSiteDbEntities _entities = new FootballWebSiteDbEntities();

        public IEnumerable<JRanking> GetRanking(Guid ownerId)
        {
            //We need to get the competitionseasonId of the owner in order to retrieve the correct ranking
            //Its the current season championship that is playing the first team 

            //We need to get owner first team. 
            using (TeamsRepository teamRepository = new TeamsRepository())
            {
                var firstTeam = teamRepository.GetHomeTeams(ownerId).OrderBy(o => o.DisplayOrder).First(o => o.DisplayOrder > 0);
                var currentSeason = _entities.Seasons.Single(o => o.CurrentSeason);

                var competitionSeasonId = _entities.TeamCompetitionSeasons.Single(o => o.TeamId == firstTeam.Id
                && o.CompetitionSeason.SeasonId == currentSeason.SeasonId
                && o.CompetitionSeason.Competition.CompetitionType1.CompetitionTypeId == 0).CompetitionSeasonId;


                return Mapper.Map(_entities.LazyRankings.Where(o => o.UpdatedDate == null
               && o.CompetitionSeasonId == competitionSeasonId).OrderBy(o => o.Position));
            }
        }

        public IEnumerable<JRanking> GetRankingFromUrl(string url)
        {
            var ranking = Mapper.Map(RankingExctractor.GetRankigFromLgefUrl(url));
            return ranking;
        }


        public void SaveRanking(IEnumerable<LazyRanking> items, Guid competitionSeasonId)
        {
            var now = DateTime.Now;
            foreach (var lazyRanking in _entities.LazyRankings.Where(o => o.UpdatedDate == null && o.CompetitionSeasonId == competitionSeasonId))
            {
                lazyRanking.UpdatedDate = now;
            }

            foreach (LazyRanking lazyRanking in items)
            {
                lazyRanking.RankingId = Guid.NewGuid();
                lazyRanking.UploadDate = now;
                lazyRanking.CompetitionSeasonId = competitionSeasonId;
                _entities.LazyRankings.Add(lazyRanking);
            }

            _entities.SaveChanges();
        }

        public JCompetitionSeason GetChampionshipData(Guid ownerId)
        {
            using (TeamsRepository teamRepository = new TeamsRepository())
            {
                var firstTeam = teamRepository.GetHomeTeams(ownerId).OrderBy(o => o.DisplayOrder).First(o => o.DisplayOrder > 0);
                var currentSeason = _entities.Seasons.Single(o => o.CurrentSeason);

                var teamCompetitionSeason = _entities.TeamCompetitionSeasons.Single(o => o.TeamId == firstTeam.Id
                && o.CompetitionSeason.SeasonId == currentSeason.SeasonId
                && o.CompetitionSeason.Competition.CompetitionType1.CompetitionTypeId == 0);

                return Mapper.Map(teamCompetitionSeason);
            }
        }

        public IEnumerable<JCompetitionSeason> GetSeasonCompetitions(Guid ownerId)
        {
            using (TeamsRepository teamRepository = new TeamsRepository())
            {
                var firstTeam = teamRepository.GetHomeTeams(ownerId).OrderBy(o => o.DisplayOrder).First(o => o.DisplayOrder > 0);
                var currentSeason = _entities.Seasons.Single(o => o.CurrentSeason);

                var teamCompetitionSeason = _entities.TeamCompetitionSeasons.Where(o => o.TeamId == firstTeam.Id
                && o.CompetitionSeason.SeasonId == currentSeason.SeasonId);

                return Mapper.Map(teamCompetitionSeason);
            }

        }

        public void UpdateRanking(Guid ownerId)
        {
            //Get the LGEF Url
            using (TeamsRepository teamRepository = new TeamsRepository())
            {
                var firstTeam = teamRepository.GetHomeTeams(ownerId).OrderBy(o => o.DisplayOrder).First(o => o.DisplayOrder > 0);
                var currentSeason = _entities.Seasons.Single(o => o.CurrentSeason);

                var teamCompetitionSeason = _entities.TeamCompetitionSeasons.Single(o => o.TeamId == firstTeam.Id
                && o.CompetitionSeason.SeasonId == currentSeason.SeasonId
                && o.CompetitionSeason.Competition.CompetitionType1.CompetitionTypeId == 0);


                var items = RankingExctractor.GetRankigFromLgefUrl(teamCompetitionSeason.CompetitionSeason.LafaUrl);

                SaveRanking(items, teamCompetitionSeason.CompetitionSeasonId);
            }
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

        ~LazyRankingRepository()
        {
            Dispose(false);
        }

        #endregion
    }
}
