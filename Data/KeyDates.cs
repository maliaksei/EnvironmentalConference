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
    
    public partial class KeyDates
    {
        public int KeyDateId { get; set; }
        public System.DateTime StaDate { get; set; }
        public string Description { get; set; }
        public int ConferenceId { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
    
        public virtual Conferences Conferences { get; set; }
    }
}
