using System;

namespace FootballWebSiteApi.Models
{
    public class JEvent
    {
        public Guid EventId { get; set; }
        public Guid GamePlayerId { get; set; }

        public Guid PlayerId { get; set; }

        public Guid GameId { get; set; }

        public int EventTypeId { get; set; }

        public string EventType { get; set; }

        public int Time { get; set; }

        public string PlayerFirstName { get; set; }

        public string PlayerLastName { get; set; }

    }
}
