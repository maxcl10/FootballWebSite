using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballWebSiteApi.Models
{
    public class JRanking
    {
        public string team { get; set; }
        public Nullable<int> position { get; set; }
        public Nullable<int> points { get; set; }
        public Nullable<int> matchPlayed { get; set; }
        public Nullable<int> matchWon { get; set; }
        public Nullable<int> matchDraw { get; set; }
        public Nullable<int> matchLost { get; set; }
        public Nullable<int> goalsScored { get; set; }
        public Nullable<int> goalsAgainst { get; set; }
        public Nullable<int> goalDifference { get; set; }
        public Nullable<int> withdaw { get; set; }
        public Nullable<int> penality { get; set; }
    }
}