using Models.JqGridModels;

namespace Models.ViewModels.RegisterForConference
{
    public class RegisterForConferenceViewModel
    {
        public RegisterForConferenceViewModel()
        {
            UserReportsViewModel = new UserReportsViewModel();
        }

        public int ConferenceId { get; set; }

        public UserReportsViewModel UserReportsViewModel { get; set; }

        public RegisterForConferenceOtherDataViewModel RegisterForConferenceOtherData { get; set; }
    }
}
