//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FootballWebSiteApi.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ranking
    {
        public System.Guid ChampionshipId { get; set; }
        public System.Guid TeamId { get; set; }
        public int Position { get; set; }
        public int Points { get; set; }
        public int MatchPlayed { get; set; }
        public int MatchWon { get; set; }
        public int MatchDraw { get; set; }
        public int MatchLost { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference { get; set; }
        public int Withdraw { get; set; }
        public int Penality { get; set; }
        public Nullable<System.Guid> SeasonId { get; set; }
    }
}
