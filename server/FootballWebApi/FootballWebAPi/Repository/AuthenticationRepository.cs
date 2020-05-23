using System;
using System.Linq;
using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Interfaces;

namespace FootballWebSiteApi.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private FootballWebSiteDbEntities _entities;

        public AuthenticationRepository()
        {
            _entities = new FootballWebSiteDbEntities();
        }

        public User IsAuthorized(Guid ownerId, string alias, string password)
        {
            var user = _entities.Users.SingleOrDefault(o => o.alias == alias && o.password == password && o.ownerId == ownerId);
            if (user == null)
            {
                return null;
            }
            return user;
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

        ~AuthenticationRepository()
        {
            Dispose(false);
        }

        #endregion
    }
}
