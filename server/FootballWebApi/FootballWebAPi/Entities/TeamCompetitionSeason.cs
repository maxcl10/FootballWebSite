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
    
    public partial class TeamCompetitionSeason
    {
        public System.Guid TeamCompetitionSeasonId { get; set; }
        public System.Guid TeamId { get; set; }
        public System.Guid CompetitionSeasonId { get; set; }
        public string LafaName { get; set; }
        public string CompetitionGroup { get; set; }
    
        public virtual CompetitionSeason CompetitionSeason { get; set; }
        public virtual Team Team { get; set; }
    }
}
