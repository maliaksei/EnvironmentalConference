using System;

namespace Models.ViewModels.EditConferenceViewModels
{
    public class FilesOfConferenceViewModel
    {
        public Guid FileConferenceId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
        public int ConferenceId { get; set; }
    }
}
