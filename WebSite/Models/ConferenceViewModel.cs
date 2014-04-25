using Models.ViewModels;

namespace WebSite.Models
{
    public class ConferenceViewModel
    {
        public ConferenceViewModel()
        {
            KeyDatesModel = new KeyDatesJqGridModel();
        }

        public SummaryViewModel Summary { get; set; }

        public KeyDatesJqGridModel KeyDatesModel { get; set; }
    }
}