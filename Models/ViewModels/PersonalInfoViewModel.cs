using Models.ViewModels.UserAccount;

namespace Models.ViewModels
{
    public class PersonalInfoViewModel
    {
        public UserInfoViewModel UserInfo { get; set; }

        public ViewActiveConferencesViewModel ViewActiveConferences{ get; set; }
    }
}
