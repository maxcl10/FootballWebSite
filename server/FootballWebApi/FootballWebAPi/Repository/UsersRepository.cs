using System;
using System.Collections.Generic;
using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Interfaces;

namespace FootballWebSiteApi.Repository
{
    public class UsersRepository : IUserRepository
    {

        private FootballWebSiteDbEntities _entities;

        public UsersRepository()
        {
            _entities = new FootballWebSiteDbEntities();
        }

        public IEnumerable<User> GetUsers()
        {
            return _entities.Users;
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

        ~UsersRepository()
        {
            Dispose(false);
        }

        #endregion
    }
}
