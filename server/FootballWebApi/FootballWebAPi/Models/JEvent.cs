using System;

namespace FootballWebSiteApi.Models
{
    public class JEvent
    {
        public Guid eventId { get; set; }
        public Guid gamePlayerId { get; set; }

        public Guid playerId { get; set; }

        public Guid gameId { get; set; }

        public int eventTypeId { get; set; }

        public string eventType { get; set; }

        public int time { get; set; }

        public string playerFirstName { get; set; }

        public string playerLastName { get; set; }

    }
}
