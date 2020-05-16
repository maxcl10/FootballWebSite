using System;

namespace FootballWebSiteApi.Models
{
    public class JUser
    {
        public Guid UserId { get; set; }
        public string Alias { get; set; }
        public string Email { get; set; }
        public string LastName { get; internal set; }
        public string FirstName { get; internal set; }
    }
}
