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

        public IEnumerable<JRanking> Get()
        {
            //We need to get the competitionseasonId of the owner in order to retrieve the correct ranking
            //Its the current season championship that is playing the first team 

            //We need to get owner first team. 
            using (TeamsRepository teamRepository = new TeamsRepository())
            {
                var firstTeam = teamRepository.GetHomeTeams().OrderBy(o => o.DisplayOrder).First();
                var currentSeason = _entities.Seasons.Single(o => o.currentSeason);

                var competitionSeasonId = _entities.TeamCompetitionSeasons.Single(o => o.teamId == firstTeam.Id
                && o.CompetitionSeason.seasonId == currentSeason.id
                && o.CompetitionSeason.Competition.CompetitionType1.competitionTypeId == 0).competitionSeasonId;


                return Mapper.Map(_entities.LazyRankings.Where(o => o.updatedDate == null
               && o.competitionSeasonId == competitionSeasonId).OrderBy(o => o.position));
            }
        }

        public IEnumerable<JRanking> Get(string url)
        {
            var ranking = Mapper.Map(RankingExctractor.GetRankigFromLgefUrl(url));
            return ranking;
        }

        public JRanking Post(LazyRanking value)
        {
            throw new NotImplementedException();
        }

        public JRanking Put(string id, LazyRanking value)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void SaveRanking(IEnumerable<LazyRanking> items, Guid competitionSeasonId)
        {
            var now = DateTime.Now;
            foreach (var lazyRanking in _entities.LazyRankings.Where(o => o.updatedDate == null && o.competitionSeasonId == competitionSeasonId))
            {
                lazyRanking.updatedDate = now;
            }

            foreach (LazyRanking lazyRanking in items)
            {
                lazyRanking.rankingId = Guid.NewGuid();
                lazyRanking.uploadDate = now;
                lazyRanking.competitionSeasonId = competitionSeasonId;
                _entities.LazyRankings.Add(lazyRanking);
            }

            _entities.SaveChanges();
        }

        public JCompetitionSeason GetChampionshipData()
        {
            using (TeamsRepository teamRepository = new TeamsRepository())
            {
                var firstTeam = teamRepository.GetHomeTeams().OrderBy(o => o.DisplayOrder).First();
                var currentSeason = _entities.Seasons.Single(o => o.currentSeason);

                var teamCompetitionSeason = _entities.TeamCompetitionSeasons.Single(o => o.teamId == firstTeam.Id
                && o.CompetitionSeason.seasonId == currentSeason.id
                && o.CompetitionSeason.Competition.CompetitionType1.competitionTypeId == 0);

                return Mapper.Map(teamCompetitionSeason);
            }
        }

        public IEnumerable<JCompetitionSeason> GetSeasonCompetitions()
        {
            using (TeamsRepository teamRepository = new TeamsRepository())
            {
                var firstTeam = teamRepository.GetHomeTeams().OrderBy(o => o.DisplayOrder).First();
                var currentSeason = _entities.Seasons.Single(o => o.currentSeason);

                var teamCompetitionSeason = _entities.TeamCompetitionSeasons.Where(o => o.teamId == firstTeam.Id
                && o.CompetitionSeason.seasonId == currentSeason.id);

                return Mapper.Map(teamCompetitionSeason);
            }

        }

        public void UpdateRanking()
        {
            //Get the LGEF Url
            using (TeamsRepository teamRepository = new TeamsRepository())
            {
                var firstTeam = teamRepository.GetHomeTeams().OrderBy(o => o.DisplayOrder).First();
                var currentSeason = _entities.Seasons.Single(o => o.currentSeason);

                var teamCompetitionSeason = _entities.TeamCompetitionSeasons.Single(o => o.teamId == firstTeam.Id
                && o.CompetitionSeason.seasonId == currentSeason.id
                && o.CompetitionSeason.Competition.CompetitionType1.competitionTypeId == 0);


                var items = RankingExctractor.GetRankigFromLgefUrl(teamCompetitionSeason.CompetitionSeason.lafaUrl);

                SaveRanking(items, teamCompetitionSeason.competitionSeasonId);
            }
        }


        public JRanking Post(JRanking value)
        {
            throw new NotImplementedException();
        }

        public JRanking Put(string id, JRanking value)
        {
            throw new NotImplementedException();
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
