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
    
    public partial class Sponsor
    {
        public System.Guid sponsorId { get; set; }
        public string name { get; set; }
        public string logoUrl { get; set; }
        public string siteUrl { get; set; }
        public int orderIndex { get; set; }
        public System.Guid ownerId { get; set; }
    
        public virtual Owner Owner { get; set; }
    }
}
