using System;

namespace FootballWebSiteApi.Models
{
    public class JGamePlayer
    {
        public Guid id { get; set; }
        public Guid playerId { get; set; }
        public string position { get; set; }
        public string globalPosition { get; set; }

        public string playerFirstName { get; set; }
        public string playerLastName { get; set; }
    }
}
