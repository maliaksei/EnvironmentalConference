using Models.JqGridModels;

namespace Models.ViewModels.EditConferenceViewModels
{
    public class ConferenceViewModel
    {
        public ConferenceViewModel()
        {
            KeyDatesModel = new KeyDatesJqGridModel();
            ResearchAreas = new ResearchAreasJqGridModel();
            OrganizingCommittee = new OrganizingCommitteeViewModel();
            FilesOfConference = new FilesOfConferenceJqGridModel();
        }

        public SummaryViewModel Summary { get; set; }

        public KeyDatesJqGridModel KeyDatesModel { get; set; }

        public ResearchAreasJqGridModel ResearchAreas { get; set; }

        public OrganizingCommitteeViewModel OrganizingCommittee { get; set; }

        public FilesOfConferenceJqGridModel FilesOfConference { get; set; }

        public FormOfParticipationViewModel FormOfParticipation { get; set; }

        public FinanceAndLayoutViewModel FinanceAndLayout { get; set; }
    }
}