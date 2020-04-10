using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballWebSiteApi.Models
{
    public class JPlayer
    {
        public Guid id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public System.DateTime? dateOfBirth { get; set; }
        public int? height { get; set; }
        public int? weight { get; set; }
        public string nationality { get; set; }
        public string position { get; set; }
        public string previousClubs { get; set; }
        public string nickname { get; set; }
        public string favoritePlayer { get; set; }
        public string favoriteNumber { get; set; }
        public string favoriteTeam { get; set; }

    }
}