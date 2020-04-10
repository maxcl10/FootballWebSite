using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballWebSiteApi.Repository
{
    public class LazyRankingRepository : IDatabaseRepository<JRanking>, IDisposable
    {
        FootballWebSiteDbEntities entities = new FootballWebSiteDbEntities();

        public IEnumerable<JRanking> Get()
        {
            //We need to get the competitionseasonId of the owner in order to retrieve the correct ranking
            //Its the current season championship that is playing the first team 

            //We need to get owner first team. 
            using (TeamsRepository teamRepository = new TeamsRepository())
            {
                var firstTeam = teamRepository.GetHomeTeams().OrderBy(o => o.displayOrder).First();
                var currentSeason = entities.Seasons.Single(o => o.currentSeason);

                var competitionSeasonId = entities.TeamCompetitionSeasons.Single(o => o.teamId == firstTeam.id
                && o.CompetitionSeason.seasonId == currentSeason.id
                && o.CompetitionSeason.Competition.CompetitionType1.competitionTypeId == 0).competitionSeasonId;


                return Mapper.Map(entities.LazyRankings.Where(o => o.updatedDate == null
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

        public void Dispose()
        {
            entities.Dispose();
        }

        public void SaveRanking(IEnumerable<LazyRanking> items, Guid competitionSeasonId)
        {
            var now = DateTime.Now;
            foreach (var lazyRanking in entities.LazyRankings.Where(o => o.updatedDate == null && o.competitionSeasonId == competitionSeasonId))
            {
                lazyRanking.updatedDate = now;
            }

            foreach (LazyRanking lazyRanking in items)
            {
                lazyRanking.rankingId = Guid.NewGuid();
                lazyRanking.uploadDate = now;
                lazyRanking.competitionSeasonId = competitionSeasonId;
                entities.LazyRankings.Add(lazyRanking);
            }

            entities.SaveChanges();
        }

        internal JCompetitionSeason GetChampionshipData()
        {
            using (TeamsRepository teamRepository = new TeamsRepository())
            {
                var firstTeam = teamRepository.GetHomeTeams().OrderBy(o => o.displayOrder).First();
                var currentSeason = entities.Seasons.Single(o => o.currentSeason);

                var teamCompetitionSeason = entities.TeamCompetitionSeasons.Single(o => o.teamId == firstTeam.id
                && o.CompetitionSeason.seasonId == currentSeason.id
                && o.CompetitionSeason.Competition.CompetitionType1.competitionTypeId == 0);

                return Mapper.Map(teamCompetitionSeason);
            }
        }

        public IEnumerable<JCompetitionSeason> GetSeasonCompetitions()
        {
            using (TeamsRepository teamRepository = new TeamsRepository())
            {
                var firstTeam = teamRepository.GetHomeTeams().OrderBy(o => o.displayOrder).First();
                var currentSeason = entities.Seasons.Single(o => o.currentSeason);

                var teamCompetitionSeason = entities.TeamCompetitionSeasons.Where(o => o.teamId == firstTeam.id
                && o.CompetitionSeason.seasonId == currentSeason.id);

                return Mapper.Map(teamCompetitionSeason);
            }

        }

        public void UpdateRanking()
        {
            //Get the LGEF Url
            using (TeamsRepository teamRepository = new TeamsRepository())
            {
                var firstTeam = teamRepository.GetHomeTeams().OrderBy(o => o.displayOrder).First();
                var currentSeason = entities.Seasons.Single(o => o.currentSeason);

                var teamCompetitionSeason = entities.TeamCompetitionSeasons.Single(o => o.teamId == firstTeam.id
                && o.CompetitionSeason.seasonId == currentSeason.id
                && o.CompetitionSeason.Competition.CompetitionType1.competitionTypeId == 0);


                var items = RankingExctractor.GetRankigFromLgefUrl(teamCompetitionSeason.CompetitionSeason.lafaUrl);

                SaveRanking(items, teamCompetitionSeason.competitionSeasonId);
            }
        }

        JRanking IDatabaseRepository<JRanking>.Get(string id)
        {
            throw new NotImplementedException();
        }

        public JRanking Post(JRanking value)
        {
            throw new NotImplementedException();
        }

        public JRanking Put(string id, JRanking value)
        {
            throw new NotImplementedException();
        }
    }
}
