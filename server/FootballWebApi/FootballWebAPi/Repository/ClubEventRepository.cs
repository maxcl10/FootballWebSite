using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Web;

using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Interfaces;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Repository
{
    public class ClubEventsRepository : IClubEventsRepository
    {
        private FootballWebSiteDbEntities _entities;

        public ClubEventsRepository()
        {
            _entities = new FootballWebSiteDbEntities();
        }

        public async Task<IEnumerable<JClubEvent>> GetClubEvents(Guid ownerId)
        {
            var currentSeasonId = _entities.Seasons.Single(o => o.CurrentSeason).SeasonId;

            var clubEvents = await _entities.ClubEvents.Where(o => o.OwnerId == ownerId
            && o.SeasonId == currentSeasonId).OrderBy(o => o.StartDate).ToListAsync();

            return Mapper.Map(clubEvents);
        }

        public async Task<JClubEvent> GetClubEvent(Guid ownerId, Guid clubEventId)
        {
            var clubEvent = await _entities.ClubEvents.SingleAsync(o => o.OwnerId == ownerId
            && o.ClubEventId == clubEventId);

            return Mapper.Map(clubEvent);
        }

        public JClubEvent CreateClubEvent(Guid ownerId, JClubEvent jClubEvent)
        {
            jClubEvent.Id = Guid.NewGuid();
            var clubEvent = Mapper.Map(jClubEvent);
            clubEvent.OwnerId = ownerId;
            clubEvent.SeasonId = _entities.Seasons.Single(o => o.CurrentSeason).SeasonId;
            _entities.ClubEvents.Add(clubEvent);
            _entities.SaveChanges();
            return jClubEvent;
        }

        public async Task<JClubEvent> UpdateClubEvent(Guid ownerId, Guid clubEventId, JClubEvent jClubEvent)
        {
            var clubEvent = await _entities.ClubEvents.SingleAsync(o => o.ClubEventId == clubEventId && o.OwnerId == ownerId);
            clubEvent.Name = jClubEvent.Name;
            clubEvent.Description = jClubEvent.Description;
            clubEvent.StartDate = jClubEvent.StartDate;
            clubEvent.EndDate = jClubEvent.EndDate;
            clubEvent.Location = jClubEvent.Location;
            clubEvent.City = jClubEvent.City;
            clubEvent.ImageUrl = jClubEvent.ImageUrl;
            clubEvent.Canceled = jClubEvent.Canceled;

            _entities.SaveChanges();
            return jClubEvent;
        }

        public async Task DeleteClubEvent(Guid ownerId, Guid clubEventId)
        {
            var teamToDelete = await _entities.ClubEvents.SingleAsync(o => o.OwnerId == ownerId && o.ClubEventId == clubEventId);
            _entities.ClubEvents.Remove(teamToDelete);
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

        ~ClubEventsRepository()
        {
            Dispose(false);
        }

        #endregion
    }
}
