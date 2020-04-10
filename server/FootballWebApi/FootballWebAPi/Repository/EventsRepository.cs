using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballWebSiteApi.Repository
{
    public class EventsRepository : IDisposable
    {
        private FootballWebSiteDbEntities entities;

        public EventsRepository()
        {
            entities = new FootballWebSiteDbEntities();
        }

        public List<JEvent> GetEventsByGame(Guid gameId)
        {
            var events = entities.GameEvents.Where(o => o.PlayerGame.GameId == gameId);
            return Mapper.Map(events);
        }

        public JEvent CreateEvent(JEvent gameEvent)
        {
            gameEvent.eventId = Guid.NewGuid();

            entities.GameEvents.Add(new GameEvent
            {
                EventTypeId = gameEvent.eventTypeId,
                GameEventId = gameEvent.eventId,
                PlayeGameId = gameEvent.gamePlayerId,
                Time = gameEvent.time
            });

            entities.SaveChanges();

            return gameEvent;

            //get the entities back
            //return Mapper.Map(entities.GameEvents.Single(o => o.GameEventId == gameEvent.eventId));
        }

        public void DeleteEvent(Guid eventId)
        {
            var corresponding = entities.GameEvents.Single(o => o.GameEventId == eventId);
            entities.GameEvents.Remove(corresponding);
            entities.SaveChanges();
        }

        public void Dispose()
        {
            entities.Dispose();
        }
    }
}
