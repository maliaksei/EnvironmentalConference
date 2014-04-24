using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.ViewModels.EditConferenceViewModels;

namespace Models.ViewModels
{
    public class DetailsOfTheConferenceViewModel
    {
        public int ConferenceId { get; set; }

        public SummaryViewModel Summary { get; set; }
    }
}
