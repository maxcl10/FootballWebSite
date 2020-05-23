using System;
using System.Linq;
using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Interfaces;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private FootballWebSiteDbEntities _entities;

        public OwnerRepository()
        {
            _entities = new FootballWebSiteDbEntities();
        }

        public JOwner GetOwner(Guid ownerId)
        {
            var owner = Mapper.Map(_entities.Owners.Single(o => o.ownerId == ownerId));
            return owner;
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

        ~OwnerRepository()
        {
            Dispose(false);
        }

        #endregion
    }
}
