using Models.JqGridModels;

namespace Models.ViewModels.EditConferenceViewModels
{
    public class FormOfParticipationViewModel
    {
        public FormOfParticipationViewModel()
        {
            FormOfParticipationJqGrid = new FormOfParticipationJqGridModel();
            LanguagesConferenceJqGrid= new LanguagesConferenceJqGridModel();
        }

        public int ConferenceId { get; set; }

        public string ConditionsOfParticipation { get; set; }

        public string ArrangementFee { get; set; }

        public FormOfParticipationJqGridModel FormOfParticipationJqGrid { get; set; }

        public LanguagesConferenceJqGridModel LanguagesConferenceJqGrid { get; set; }
    }
}
