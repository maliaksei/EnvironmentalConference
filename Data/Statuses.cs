//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Diplom.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Statuses
    {
        public Statuses()
        {
            this.ConferenceStatus = new HashSet<ConferenceStatus>();
        }
    
        public int StatusesId { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<ConferenceStatus> ConferenceStatus { get; set; }
    }
}
