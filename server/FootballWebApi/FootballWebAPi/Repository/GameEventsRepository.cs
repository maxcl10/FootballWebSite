using System;
using System.Collections.Generic;
using System.Linq;
using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Interfaces;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Repository
{
    public class GameEventsRepository : IGameEventsRepository
    {
        private FootballWebSiteDbEntities _entities;

        public GameEventsRepository()
        {
            _entities = new FootballWebSiteDbEntities();
        }

        public List<JGameEvent> GetEventsByGame(Guid gameId)
        {
            var events = _entities.GameEvents.Where(o => o.PlayerGame.GameId == gameId);
            return Mapper.Map(events);
        }

        public JGameEvent CreateEvent(JGameEvent gameEvent)
        {
            gameEvent.EventId = Guid.NewGuid();

            _entities.GameEvents.Add(new GameEvent
            {
                EventTypeId = gameEvent.EventTypeId,
                GameEventId = gameEvent.EventId,
                PlayeGameId = gameEvent.GamePlayerId,
                Time = gameEvent.Time
            });

            _entities.SaveChanges();

            return gameEvent;

            //get the entities back
            //return Mapper.Map(entities.GameEvents.Single(o => o.GameEventId == gameEvent.eventId));
        }

        public IEnumerable<JEventType> GetGameEventTypes()
        {
            var eventTypes = _entities.GameEventTypes;
            return Mapper.Map(eventTypes);

        }

        public void DeleteEvent(Guid eventId)
        {
            var corresponding = _entities.GameEvents.Single(o => o.GameEventId == eventId);
            _entities.GameEvents.Remove(corresponding);
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

        ~GameEventsRepository()
        {
            Dispose(false);
        }

        #endregion
    }
}
