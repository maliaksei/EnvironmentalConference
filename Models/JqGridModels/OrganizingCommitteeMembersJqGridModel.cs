using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Models.Properties;
using Trirand.Web.Mvc;

namespace Models.JqGridModels
{
    public class OrganizingCommitteeMembersJqGridModel
    {
        private readonly UrlHelper _url = new UrlHelper(HttpContext.Current.Request.RequestContext);

        public OrganizingCommitteeMembersJqGridModel()
        {
            OrdersGrid = new JQGrid
            {
                Columns = new List<JQGridColumn>()
                {
                    new JQGridColumn
                    {
                        DataField = "OrganizingCommitteeMembersId",
                        PrimaryKey = true,
                        Editable = false,
                        Visible = false,
                        Width = 50
                    },
                    new JQGridColumn
                    {
                        DataField = "FullName",
                        HeaderText = Resources.OrganizingCommitteeMembers_FullName,
                        Editable = false,
                        Searchable = false,
                        Width = 100
                    },
                    new JQGridColumn
                    {
                        DataField = "Surname",
                        HeaderText = Resources.OrganizingCommitteeMembers_Surname,
                        Editable = true,
                        Searchable = false,
                        Visible = false,
                        EditClientSideValidators = new List<JQGridEditClientSideValidator> {new RequiredValidator()},
                        Width = 100
                    },
                    new JQGridColumn
                    {
                        DataField = "Name",
                        HeaderText = Resources.OrganizingCommitteeMembers_Name,
                        Editable = true,
                        Searchable = false,
                        Visible = false,
                        EditClientSideValidators = new List<JQGridEditClientSideValidator> {new RequiredValidator()},
                        Width = 100
                    },
                    new JQGridColumn
                    {
                        DataField = "Patronymic",
                        HeaderText = Resources.OrganizingCommitteeMembers_Patronymic,
                        Editable = true,
                        Searchable = false,
                        Visible = false,
                        EditClientSideValidators = new List<JQGridEditClientSideValidator> {new RequiredValidator()},
                        Width = 100
                    },
                    new JQGridColumn
                    {
                        DataField = "Post",
                        HeaderText = Resources.OrganizingCommitteeMembers_Post,
                        Editable = true,
                        Searchable = false,
                        EditClientSideValidators = new List<JQGridEditClientSideValidator> {new RequiredValidator()},
                        Width = 100
                    },
                    new JQGridColumn
                    {
                        DataField = "AdditionalInformation",
                        HeaderText = Resources.OrganizingCommitteeMembers_AdditionalInformation,
                        Editable = true,
                        Searchable = false,
                        EditType = EditType.TextArea
                    },
                    new JQGridColumn
                    {
                        DataField = "OrganizingCommitteeId",
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
                ID = "OrganizingCommitteeMembersJQGrid",
                EditUrl = _url.Action("OrganizingCommitteeMembersAddEditJsonResult", "JqGrid"),
                DataUrl = _url.Action("OrganizingCommitteeMembersDataBindJsonResult", "JqGrid"),
                Width = Unit.Pixel(640)
            };
        }

        public JQGrid OrdersGrid { get; set; }

    }

}