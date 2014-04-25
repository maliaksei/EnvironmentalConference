using System;
using Diplom.Data;
using Models.ViewModels;
using Models.ViewModels.EditConferenceViewModels;

namespace Helpers
{
    public static class KeyDatesHelper
    {
        public static KeyDates KeyDatesViewModelToDataModel(KeyDatesViewModel viewModel)
        {
            if (viewModel.StartDate == null)
                return null;

            return new KeyDates
            {
                KeyDateId = viewModel.DateId,
                StaDate = DateTime.Parse(viewModel.StartDate),
                EndDate = viewModel.EndDate != null? DateTime.Parse(viewModel.EndDate) : (DateTime?)null,
                Description = viewModel.Description,
                ConferenceId = viewModel.ConferenceId
            };
        }
    }
}
