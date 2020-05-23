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
            return Mapper.Map(_entities.Teams.OrderBy(o => o.name));
        }

        public IEnumerable<JTeam> GetHomeTeams(Guid ownerId)
        {
            return Mapper.Map(_entities.Teams.Where(o => o.ownerId == ownerId).OrderBy(o => o.displayOrder));
        }

        public IEnumerable<JPlayer> GetPlayers(Guid ownerId, Guid id)
        {
            List<JPlayer> players = new List<JPlayer>();
            var currentSeason = _entities.Seasons.First(p => p.currentSeason);
            var playersId = _entities.PlayerTeams.Where(o => o.teamId == id && o.seasonId == currentSeason.id && o.Team.ownerId == ownerId);
            foreach (PlayerTeam playerTeam in playersId)
            {
                players.Add(Mapper.Map(playerTeam.Player));
            }

            return players.OrderBy(o => o.Position);
        }

        public JTeam Get(Guid id)
        {
            return Mapper.Map(_entities.Teams.Single(o => o.id == id));
        }

        public JTeam Post(JTeam jteam)
        {
            jteam.Id = Guid.NewGuid();
            Team team = Mapper.Map(jteam);

            _entities.Teams.Add(team);
            _entities.SaveChanges();

            return jteam;
        }

        public JTeam Put(Guid id, JTeam team)
        {
            var correspondingTeam = _entities.Teams.Single(o => o.id == id);
            correspondingTeam.name = team.Name;
            correspondingTeam.shortName = team.ShortName;

            _entities.SaveChanges();
            return team;
        }

        public void Delete(Guid id)
        {
            var teamToDelete = _entities.Teams.Single(o => o.id == id);
            _entities.Teams.Remove(teamToDelete);
            _entities.SaveChanges();
        }


        public void AddPlayer(Guid playerId, Guid teamId)
        {
            var currentSeason = _entities.Seasons.First(o => o.currentSeason);

            //Check if already exist
            if (_entities.PlayerTeams.Any(o => o.playerId == playerId && o.teamId == teamId && o.seasonId == currentSeason.id))
            {
                throw new Exception("Player already exists");
            }
            else
            {
                PlayerTeam playerTeam = new PlayerTeam
                {
                    playerId = playerId,
                    teamId = teamId,
                    playerTeamId = Guid.NewGuid(),
                    seasonId = currentSeason.id
                };

                _entities.PlayerTeams.Add(playerTeam);
                _entities.SaveChanges();
            }

        }

        public void RemovePlayer(Guid playerId, Guid teamId)
        {
            var entity = _entities.PlayerTeams.FirstOrDefault(o => o.playerId == playerId && o.teamId == teamId);
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
