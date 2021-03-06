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
    
    public partial class ClubEvent
    {
        public System.Guid ClubEventId { get; set; }
        public string Name { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public System.Guid OwnerId { get; set; }
        public Nullable<System.Guid> SeasonId { get; set; }
        public string ImageUrl { get; set; }
        public Nullable<bool> Canceled { get; set; }
    
        public virtual Owner Owner { get; set; }
        public virtual Season Season { get; set; }
    }
}
