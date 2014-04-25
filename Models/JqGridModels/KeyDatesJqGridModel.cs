using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Models.Properties;
using Trirand.Web.Mvc;

namespace Models.JqGridModels
{
    public class KeyDatesJqGridModel
    {
        private readonly UrlHelper _url = new UrlHelper(HttpContext.Current.Request.RequestContext);

        public KeyDatesJqGridModel()
        {
            OrdersGrid = new JQGrid
            {
                Columns = new List<JQGridColumn>()
                {
                    new JQGridColumn
                    {
                        DataField = "DateId",
                        //HeaderText = Resources.KeyDates_DateId,
                        PrimaryKey = true,
                        Editable = false,
                        Visible = false,
                        Width = 50
                    },
                    new JQGridColumn
                    {
                        DataField = "StartDate",
                        HeaderText = Resources.KeyDates_StartDate,
                        Editable = true,
                        Searchable = false,
                        EditClientSideValidators = new List<JQGridEditClientSideValidator> {new RequiredValidator()},
                        DataFormatString = "{0:yyyy/MM/dd}",
                        EditType = EditType.DatePicker,
                        EditorControlID = "DatePicker",
                        Width = 100
                    },
                    new JQGridColumn
                    {
                        DataField = "EndDate",
                        HeaderText = Resources.KeyDates_EndDate,
                        Editable = true,
                        Searchable = false,
                        DataFormatString = "{0:yyyy/MM/dd}",
                        EditType = EditType.DatePicker,
                        EditorControlID = "DatePicker",
                        Width = 100
                    },
                    new JQGridColumn
                    {
                        DataField = "Description",
                        HeaderText = Resources.KeyDates_Description,
                        EditClientSideValidators = new List<JQGridEditClientSideValidator> {new RequiredValidator()},
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
                ID = "OrdersGrid1",
                EditUrl = _url.Action("KeyDatesAddEditJsonResult", "JqGrid"),
                DataUrl = _url.Action("KeyDatesDataBindJsonResult", "JqGrid"),
                Width = Unit.Pixel(640)
            };
        }

        public JQGrid OrdersGrid { get; set; }

    }

}