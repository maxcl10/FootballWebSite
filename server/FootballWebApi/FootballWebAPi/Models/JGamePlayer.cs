using System;

namespace FootballWebSiteApi.Models
{
    public class JGamePlayer
    {
        public Guid Id { get; set; }
        public Guid PlayerId { get; set; }
        public string Position { get; set; }
        public string GlobalPosition { get; set; }

        public string PlayerFirstName { get; set; }
        public string PlayerLastName { get; set; }
    }
}
