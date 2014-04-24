using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Models.Properties;
using Repository;
using Trirand.Web.Mvc;

namespace Models.JqGridModels
{
    public class LanguagesConferenceJqGridModel
    {
        private readonly UrlHelper _url = new UrlHelper(HttpContext.Current.Request.RequestContext);

        private readonly DataManager dataManager = new DataManager();

        public LanguagesConferenceJqGridModel()
        {
            OrdersGrid = new JQGrid
            {
                Columns = new List<JQGridColumn>()
                {
                    new JQGridColumn
                    {
                        DataField = "LanguagesConferenceId",
                        //HeaderText = Resources.KeyDates_DateId,
                        PrimaryKey = true,
                        Editable = false,
                        Visible = false
                    },
                    new JQGridColumn
                    {
                        DataField = "Language",
                        HeaderText = Resources.LanguagesConference_LanguageName,
                        Editable = true,
                        Searchable = false,
                        EditType = EditType.DropDown,
                        EditList =
                            dataManager.LanguagesConferenceRepositories.GetAll().ToList()
                                .Select(
                                    x => new SelectListItem {Text = x.Name, Value = x.LanguagesId.ToString()})
                                .ToList()
                    },
                    new JQGridColumn
                    {
                        DataField = "ConferenceId",
                        Editable = false,
                        Visible = false
                    }
                },
                ToolBarSettings = new ToolBarSettings
                {
                    ShowEditButton = false,
                    ShowAddButton = true,
                    ShowDeleteButton = true,
                    ShowSearchToolBar = false

                },
                EditDialogSettings = new EditDialogSettings
                {
                    CloseAfterEditing = true,

                },
                AddDialogSettings = new AddDialogSettings
                {
                    CloseAfterAdding = true
                },
                ID = "Languages",
                EditUrl = _url.Action("LanguagesConferenceEditJsonResult", "JqGrid"),
                DataUrl = _url.Action("LanguagesConferenceDataBindJsonResult", "JqGrid"),
                Width = Unit.Pixel(600)
            };
        }

        public JQGrid OrdersGrid { get; set; }

    }

}