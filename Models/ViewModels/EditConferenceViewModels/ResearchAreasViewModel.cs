namespace Models.ViewModels.EditConferenceViewModels
{
    public class ResearchAreasViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DateTime { get; set; }
        public string Venue { get; set; }
        public string Description { get; set; }
        public int ConferenceId { get; set; }
    }
}
