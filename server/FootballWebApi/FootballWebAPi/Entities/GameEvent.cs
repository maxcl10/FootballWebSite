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
    
    public partial class GameEvent
    {
        public System.Guid GameEventId { get; set; }
        public int EventTypeId { get; set; }
        public System.Guid PlayeGameId { get; set; }
        public int Time { get; set; }
    
        public virtual GameEventType GameEventType { get; set; }
        public virtual PlayerGame PlayerGame { get; set; }
    }
}
