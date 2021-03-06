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
    
    public partial class Team
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Team()
        {
            this.Games = new HashSet<Game>();
            this.Games1 = new HashSet<Game>();
            this.PlayerTeams = new HashSet<PlayerTeam>();
            this.TeamCompetitionSeasons = new HashSet<TeamCompetitionSeason>();
        }
    
        public System.Guid TeamId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public Nullable<bool> HomeTeam { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public string DisplayName { get; set; }
        public Nullable<System.Guid> OwnerId { get; set; }
        public string CalendarUrl { get; set; }
        public string RankingUrl { get; set; }
        public Nullable<bool> YouthTeam { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Game> Games { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Game> Games1 { get; set; }
        public virtual Owner Owner { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlayerTeam> PlayerTeams { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeamCompetitionSeason> TeamCompetitionSeasons { get; set; }
    }
}
