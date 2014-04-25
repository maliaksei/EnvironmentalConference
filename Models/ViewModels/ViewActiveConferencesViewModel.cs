using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
   public class ViewActiveConferencesViewModel
    {
       public ViewActiveConferencesViewModel()
       {
           ActiveConferences = new List<SummaryForActiveConferenceViewModel>();
       }

       public IEnumerable<SummaryForActiveConferenceViewModel> ActiveConferences { get; set; } 
    }
}
