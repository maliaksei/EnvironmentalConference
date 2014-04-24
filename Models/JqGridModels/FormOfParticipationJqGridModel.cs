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
    public class FormOfParticipationJqGridModel
    {
        private readonly UrlHelper _url = new UrlHelper(HttpContext.Current.Request.RequestContext);

        private readonly DataManager dataManager = new DataManager();

        public FormOfParticipationJqGridModel()
        {
            OrdersGrid = new JQGrid
            {
                Columns = new List<JQGridColumn>()
                {
                    new JQGridColumn
                    {
                        DataField = "ConferenceFormId",
                        //HeaderText = Resources.KeyDates_DateId,
                        PrimaryKey = true,
                        Editable = false,
                        Visible = false
                    },
                    new JQGridColumn
                    {
                        DataField = "FormOfParticipationName",
                        HeaderText = Resources.FormOfParticipation_FormOfParticipationName,
                        Editable = true,
                        Searchable = false,
                        EditType = EditType.DropDown,
                        EditList =
                            dataManager.FormOfParticipationRepositories.GetAll().ToList()
                                .Select(
                                    x => new SelectListItem {Text = x.Name, Value = x.ParticipationFormId.ToString()})
                                .ToList(),
                        Width = 600
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
                AddDialogSettings = new AddDialogSettings
                {
                    CloseAfterAdding = true,
                    Width = 600
                },
                ID = "FormOfParticipation",
                EditUrl = _url.Action("FormOfParticipationEditJsonResult", "JqGrid"),
                DataUrl = _url.Action("FormOfParticipationDataBindJsonResult", "JqGrid"),
                Width = Unit.Pixel(600)
            };
        }

        public JQGrid OrdersGrid { get; set; }

    }

}