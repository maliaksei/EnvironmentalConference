using System;

namespace Models.ViewModels.EditConferenceViewModels
{
    public class OrganizingCommitteeMembersViewModel
    {
        public Guid OrganizingCommitteeMembersId { get; set; }
        public string Post { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string AdditionalInformation { get; set; }
        public int OrganizingCommitteeId { get; set; }
    }
}
