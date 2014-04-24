using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Models.Properties;
using Trirand.Web.Mvc;

namespace Models.JqGridModels
{
    public class FilesOfConferenceJqGridModel
    {
        private readonly UrlHelper _url = new UrlHelper(HttpContext.Current.Request.RequestContext);

        public FilesOfConferenceJqGridModel()
        {
            OrdersGrid = new JQGrid
            {
                Columns = new List<JQGridColumn>()
                {
                    new JQGridColumn
                    {
                        DataField = "FileConferenceId",
                        //HeaderText = Resources.KeyDates_DateId,
                        PrimaryKey = true,
                        Editable = false,
                        Visible = false,
                        Width = 50
                    },
                    new JQGridColumn
                    {
                        DataField = "Name",
                        HeaderText = Resources.FilesOfConferenceJqGridModel_Name,
                        Editable = true,
                        Searchable = false,
                        EditClientSideValidators = new List<JQGridEditClientSideValidator> {new RequiredValidator()},
                        Width = 100
                    },
                    new JQGridColumn
                    {
                        DataField = "Path",
                        HeaderText = Resources.FilesOfConferenceJqGridModel_Path,
                        Editable = true,
                        Searchable = false,
                        EditType = EditType.Custom,
                        EditTypeCustomGetValue = "getCustomFileUpload",
                        EditTypeCustomCreateElement = "customFileUpload",
                        Width = 100
                    },
                    new JQGridColumn
                    {
                        DataField = "Description",
                        HeaderText = Resources.FilesOfConferenceJqGridModel_Description,
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
                ID = "FilesOfConference",
                EditUrl = _url.Action("FilesOfConferenceAddEditJsonResult", "JqGrid"),
                DataUrl = _url.Action("FilesOfConferenceDataBindJsonResult", "JqGrid"),
                Width = Unit.Pixel(640)
            };
        }

        public JQGrid OrdersGrid { get; set; }

    }

}