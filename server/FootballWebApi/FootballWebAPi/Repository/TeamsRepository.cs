using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Interfaces;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Repository
{
    public class TeamsRepository : ITeamsRepository
    {
        private FootballWebSiteDbEntities _entities;

        public TeamsRepository()
        {
            _entities = new FootballWebSiteDbEntities();
        }

        public IEnumerable<JTeam> GetTeams()
        {
            return Mapper.Map(_entities.Teams.OrderBy(o => o.Name));
        }

        public IEnumerable<JTeam> GetHomeTeams(Guid ownerId)
        {
            return Mapper.Map(_entities.Teams.Where(o => o.OwnerId == ownerId).OrderBy(o => o.DisplayOrder));
        }

        public IEnumerable<JPlayer> GetPlayers(Guid ownerId, Guid id)
        {
            List<JPlayer> players = new List<JPlayer>();
            var currentSeason = _entities.Seasons.First(p => p.CurrentSeason);
            var playersId = _entities.PlayerTeams.Where(o => o.TeamId == id && o.SeasonId == currentSeason.SeasonId && o.Team.OwnerId == ownerId);
            foreach (PlayerTeam playerTeam in playersId)
            {
                players.Add(Mapper.Map(playerTeam.Player));
            }

            return players.OrderBy(o => o.Position);
        }

        public JTeam GetTeam(Guid id)
        {
            return Mapper.Map(_entities.Teams.Single(o => o.TeamId == id));
        }

        public JTeam CreateTeam(JTeam jteam)
        {
            jteam.Id = Guid.NewGuid();
            Team team = Mapper.Map(jteam);

            _entities.Teams.Add(team);
            _entities.SaveChanges();

            return jteam;
        }

        public JTeam UpdateTeam(Guid id, JTeam team)
        {
            var correspondingTeam = _entities.Teams.Single(o => o.TeamId == id);
            correspondingTeam.Name = team.Name;
            correspondingTeam.ShortName = team.ShortName;
            correspondingTeam.OwnerId = team.OwnerId;
            correspondingTeam.DisplayName = team.DisplayName;
            correspondingTeam.DisplayOrder = team.DisplayOrder;
            correspondingTeam.CalendarUrl = team.CalendarUrl;
            correspondingTeam.RankingUrl = team.RankingUrl;
            correspondingTeam.AffiliationNumber = team.AffiliationNumber;

            _entities.SaveChanges();
            return team;
        }

        public void Delete(Guid id)
        {
            var teamToDelete = _entities.Teams.Single(o => o.TeamId == id);
            _entities.Teams.Remove(teamToDelete);
            _entities.SaveChanges();
        }


        public void AddPlayer(Guid playerId, Guid teamId)
        {
            var currentSeason = _entities.Seasons.First(o => o.CurrentSeason);

            //Check if already exist
            if (_entities.PlayerTeams.Any(o => o.PlayerId == playerId && o.TeamId == teamId && o.SeasonId == currentSeason.SeasonId))
            {
                throw new Exception("Player already exists");
            }
            else
            {
                PlayerTeam playerTeam = new PlayerTeam
                {
                    PlayerId = playerId,
                    TeamId = teamId,
                    PlayerTeamId = Guid.NewGuid(),
                    SeasonId = currentSeason.SeasonId
                };

                _entities.PlayerTeams.Add(playerTeam);
                _entities.SaveChanges();
            }

        }

        public void RemovePlayer(Guid playerId, Guid teamId)
        {
            var entity = _entities.PlayerTeams.FirstOrDefault(o => o.PlayerId == playerId && o.TeamId == teamId);
            _entities?.PlayerTeams.Remove(entity);
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

        ~TeamsRepository()
        {
            Dispose(false);
        }

        #endregion

    }
}
