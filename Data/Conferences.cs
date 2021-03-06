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
    
    public partial class Conferences
    {
        public Conferences()
        {
            this.Application = new HashSet<Application>();
            this.ConferenceForms = new HashSet<ConferenceForms>();
            this.ConferenceStatus = new HashSet<ConferenceStatus>();
            this.FilesConference = new HashSet<FilesConference>();
            this.KeyDates = new HashSet<KeyDates>();
            this.LanguagesConference = new HashSet<LanguagesConference>();
            this.Messages = new HashSet<Messages>();
            this.OrganizingCommittee = new HashSet<OrganizingCommittee>();
            this.ResearchAreas = new HashSet<ResearchAreas>();
        }
    
        public int ConferenceId { get; set; }
        public string Name { get; set; }
        public string BriefInformation { get; set; }
        public System.DateTime StartDate { get; set; }
        public string MeetingPoint { get; set; }
        public string ConditionsOfParticipation { get; set; }
        public string ArrangementFee { get; set; }
        public string FinancialConditions { get; set; }
        public string RequirementsForTheMaterials { get; set; }
    
        public virtual ICollection<Application> Application { get; set; }
        public virtual ICollection<ConferenceForms> ConferenceForms { get; set; }
        public virtual ICollection<ConferenceStatus> ConferenceStatus { get; set; }
        public virtual ICollection<FilesConference> FilesConference { get; set; }
        public virtual ICollection<KeyDates> KeyDates { get; set; }
        public virtual ICollection<LanguagesConference> LanguagesConference { get; set; }
        public virtual ICollection<Messages> Messages { get; set; }
        public virtual ICollection<OrganizingCommittee> OrganizingCommittee { get; set; }
        public virtual ICollection<ResearchAreas> ResearchAreas { get; set; }
    }
}
