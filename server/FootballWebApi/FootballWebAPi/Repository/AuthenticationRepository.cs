using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using FootballWebSiteApi.Helpers;

namespace FootballWebSiteApi.Repository
{
    public class AuthenticationRepository : IDisposable
    {
        private FootballWebSiteDbEntities entities;

        public AuthenticationRepository()
        {
            entities = new FootballWebSiteDbEntities();
        }

        public User IsAuthorized(string alias, string password)
        {
            var user = entities.Users.SingleOrDefault(o => o.alias == alias && o.password == password && o.ownerId.ToString() == Properties.Settings.Default.OwnerId);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public void Dispose()
        {
            entities.Dispose();
        }
    }
}