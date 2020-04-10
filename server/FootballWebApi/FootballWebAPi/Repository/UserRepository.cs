using FootballWebSiteApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballWebSiteApi.Repository
{
    public class UserRepository : IDisposable
    {

        private FootballWebSiteDbEntities entities;

        public UserRepository()
        {
            entities = new FootballWebSiteDbEntities();
        }
        public void Dispose()
        {
            entities.Dispose();
        }

        internal IEnumerable<User> GetAllUsers()
        {
            return entities.Users;
        }
    }
}