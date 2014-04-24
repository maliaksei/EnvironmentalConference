using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Models.Properties;
using Trirand.Web.Mvc;

namespace Models.JqGridModels
{
    public class ResearchAreasJqGridModel
    {
        private readonly UrlHelper _url = new UrlHelper(HttpContext.Current.Request.RequestContext);

        public ResearchAreasJqGridModel()
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
                        Width = 50
                    },
                    new JQGridColumn
                    {
                        DataField = "Name",
                        HeaderText = Resources.ResearchAreas_Name,
                        Editable = true,
                        Searchable = false,
                        EditClientSideValidators = new List<JQGridEditClientSideValidator> {new RequiredValidator()},
                        Width = 100
                    },
                    new JQGridColumn
                    {
                        DataField = "DateTime",
                        HeaderText = Resources.ResearchAreas_DateTime,
                        Editable = true,
                        Searchable = false,
                        DataFormatString = "{0:yyyy/MM/dd}",
                        EditType = EditType.DatePicker,
                        EditorControlID = "DatePicker",
                        Width = 100
                    },
                    new JQGridColumn
                    {
                        DataField = "Venue",
                        HeaderText = Resources.ResearchAreas_Venue,
                        EditClientSideValidators = new List<JQGridEditClientSideValidator> {new RequiredValidator()},
                        Editable = true,
                        Searchable = false,
                        Width = 100
                    },
                     new JQGridColumn
                    {
                        DataField = "Description",
                        HeaderText = Resources.ResearchAreas_Description,
                        Editable = true,
                        Searchable = false,
                        EditType = EditType.TextArea,
                        Width = 100
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
                    ShowEditButton = true,
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
                ID = "ResearchAreasJQGrid",
                EditUrl = _url.Action("ResearchAreasAddEditJsonResult", "JqGrid"),
                DataUrl = _url.Action("ResearchAreasDataBindJsonResult", "JqGrid"),
                Width = Unit.Pixel(640)
            };
        }

        public JQGrid OrdersGrid { get; set; }

    }

}