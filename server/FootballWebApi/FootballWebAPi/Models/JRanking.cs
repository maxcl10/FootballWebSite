using System;

namespace FootballWebSiteApi.Models
{
    public class JRanking
    {
        public string Team { get; set; }
        public int? Position { get; set; }
        public int? Points { get; set; }
        public int? MatchPlayed { get; set; }
        public Nullable<int> MatchWon { get; set; }
        public Nullable<int> MatchDraw { get; set; }
        public Nullable<int> MatchLost { get; set; }
        public Nullable<int> GoalsScored { get; set; }
        public Nullable<int> GoalsAgainst { get; set; }
        public Nullable<int> GoalDifference { get; set; }
        public Nullable<int> Withdaw { get; set; }
        public Nullable<int> Penality { get; set; }
    }
}
