using System;

namespace FootballWebSiteApi.Models
{
    public class JPlayer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public string Nationality { get; set; }
        public string Position { get; set; }
        public string PreviousClubs { get; set; }
        public string Nickname { get; set; }
        public string FavoritePlayer { get; set; }
        public string FavoriteNumber { get; set; }
        public string FavoriteTeam { get; set; }

    }
}
