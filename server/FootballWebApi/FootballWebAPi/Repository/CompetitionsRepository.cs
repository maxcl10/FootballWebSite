using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballWebSiteApi.Repository
{
    public class CompetitionsRepository : IDisposable
    {

        private readonly FootballWebSiteDbEntities entities;


        public CompetitionsRepository()
        {
            entities = new FootballWebSiteDbEntities();
        }

        public IEnumerable<JCompetition> Get()
        {
            return Mapper.Map(entities.Competitions);
        }

        public void Dispose()
        {
            entities.Dispose();
        }

        internal void AddTeamToCompetition(Guid teamId, Guid competitionId)
        {
            var currentSeasonId = entities.Seasons.Single(o => o.currentSeason).id;

            var competitionSeason = entities.CompetitionSeasons.SingleOrDefault(o => o.competitionId == competitionId && o.seasonId == currentSeasonId);

            if (competitionSeason == null)
            {
                //We have to create it
                competitionSeason = new CompetitionSeason
                {
                    competitionId = competitionId,
                    seasonId = currentSeasonId,
                    competitionSeasonId = Guid.NewGuid()
                };

                entities.CompetitionSeasons.Add(competitionSeason);
            }

            TeamCompetitionSeason teamCompetitionSeason = new TeamCompetitionSeason
            {
                teamId = teamId,
                teamCompetitionSeasonId = Guid.NewGuid(),
                competitionSeasonId = competitionSeason.competitionSeasonId
            };

            entities.TeamCompetitionSeasons.Add(teamCompetitionSeason);

            entities.SaveChanges();
        }
    }
}