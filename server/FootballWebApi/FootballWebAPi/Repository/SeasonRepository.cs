using System;
using System.Collections.Generic;
using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Interfaces;

namespace FootballWebSiteApi.Repository
{
    public class SeasonRepository : ISeasonRepository
    {
        private FootballWebSiteDbEntities _entities;

        public SeasonRepository()
        {
            _entities = new FootballWebSiteDbEntities();
        }

        public IEnumerable<Season> GetSeasons()
        {
            return _entities.Seasons;
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

        ~SeasonRepository()
        {
            Dispose(false);
        }

        #endregion

    }
}
