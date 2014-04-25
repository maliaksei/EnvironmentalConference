using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Models.Properties;
using Repository;
using Repository.Filters;
using Trirand.Web.Mvc;
using TextAlign = Trirand.Web.Mvc.TextAlign;

namespace Models.JqGridModels
{
    public class UserReportsJqGridModel
    {
        private readonly UrlHelper _url = new UrlHelper(HttpContext.Current.Request.RequestContext);

        private readonly DataManager dataManager = new DataManager();

        public UserReportsJqGridModel()
        {
            OrdersGrid = new JQGrid
            {
                Columns = new List<JQGridColumn>()
                {
                    new JQGridColumn
                    {
                        DataField = "Id",
                        PrimaryKey = true,
                        Editable = false,
                        Visible = false,
                        //Width = 50
                    },
                    new JQGridColumn
                    {
                        DataField = "ResearchAreas",
                        HeaderText = Resources.ResearchAreas_Name,
                        Editable = true,
                        Searchable = false,
                        EditType = EditType.DropDown,
                       // Width = 600
                    },
                    new JQGridColumn
                    {
                        DataField = "PathToReport",
                        HeaderText = Resources.ResearchAreas_PathToReport,
                        Editable = true,
                        Searchable = false,
                        Formatter = new CheckBoxFormatter(),
                        TextAlign = TextAlign.Center
                      //  Width = 100
                    },
                    new JQGridColumn
                    {
                        DataField = "PathToCheck",
                        HeaderText = Resources.ResearchAreas_PathToCheck,
                        Editable = true,
                        Searchable = false,
                        Formatter = new CheckBoxFormatter(),
                        TextAlign = TextAlign.Center
                      //  Width = 100
                    },
                    new JQGridColumn
                    {
                        DataField = "NameOfReport",
                        HeaderText = Resources.ResearchAreas_NameOfReport,
                        Editable = true,
                        Searchable = false,
                        EditClientSideValidators = new List<JQGridEditClientSideValidator> {new RequiredValidator()},
                      //  Width = 100
                    },
                    new JQGridColumn
                    {
                        DataField = "AuthorsReport",
                        HeaderText = Resources.ResearchAreas_AuthorsReport,
                        Editable = true,
                        Searchable = false,
                        EditClientSideValidators = new List<JQGridEditClientSideValidator> {new RequiredValidator()},
                      //  Width = 100
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
                    ShowDeleteButton = true,
                    CustomButtons = new List<JQGridToolBarButton>
                    {
                        new JQGridToolBarButton
                        {
                            Text = Resources.ResearchAreas_AddResearch_Button,
                            ToolTip = Resources.ResearchAreas_AddResearch_Button,
                            ButtonIcon = "ui-icon-plus",
                            Position = ToolBarButtonPosition.Last,
                            OnClick = "customButtonClicked"
                        }
                    }
                },

                EditDialogSettings = new EditDialogSettings
                {
                    CloseAfterEditing = true,

                },
                AddDialogSettings = new AddDialogSettings
                {
                    CloseAfterAdding = true
                },
                ID = "UserReportsJqGrid",
                EditUrl = _url.Action("UserReportsEditJsonResult", "JqGrid"),
                DataUrl = _url.Action("UserReportsDataBindJsonResult", "JqGrid"),
                Width = Unit.Pixel(840)
            };
        }

        public JQGrid OrdersGrid { get; set; }
    }
}
