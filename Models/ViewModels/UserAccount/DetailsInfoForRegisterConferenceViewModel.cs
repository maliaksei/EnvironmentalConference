using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.UserAccount
{
    public class DetailsInfoForRegisterConferenceViewModel
    {
        public ConferenceSummaryInfoViewModel ConferenceSummaryInfo { get; set; }

        public SummaryApplicationInfoViewModel ActiveApplicationInfoViewModel { get; set; }

        public List<QuestionViewModel> QuestionViewModels { get; set; }
    }
}
