using System;
using System.Collections.Generic;
using System.Linq;
using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Interfaces;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Repository
{
    public class CompetitionsRepository : ICompetitionsRepository
    {
        private readonly FootballWebSiteDbEntities _entities;

        public CompetitionsRepository()
        {
            _entities = new FootballWebSiteDbEntities();
        }

        public IEnumerable<JCompetition> GetCompetitions()
        {
            return Mapper.Map(_entities.Competitions);
        }

        internal void AddTeamToCompetition(Guid teamId, Guid competitionId)
        {
            var currentSeasonId = _entities.Seasons.Single(o => o.CurrentSeason).SeasonId;

            var competitionSeason = _entities.CompetitionSeasons.SingleOrDefault(o => o.CompetitionId == competitionId && o.SeasonId == currentSeasonId);

            if (competitionSeason == null)
            {
                //We have to create it
                competitionSeason = new CompetitionSeason
                {
                    CompetitionId = competitionId,
                    SeasonId = currentSeasonId,
                    CompetitionSeasonId = Guid.NewGuid()
                };

                _entities.CompetitionSeasons.Add(competitionSeason);
            }

            TeamCompetitionSeason teamCompetitionSeason = new TeamCompetitionSeason
            {
                TeamId = teamId,
                TeamCompetitionSeasonId = Guid.NewGuid(),
                CompetitionSeasonId = competitionSeason.CompetitionSeasonId
            };

            _entities.TeamCompetitionSeasons.Add(teamCompetitionSeason);

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

        ~CompetitionsRepository()
        {
            Dispose(false);
        }

        #endregion
    }
}
