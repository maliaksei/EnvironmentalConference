using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Models.Properties;
using Trirand.Web.Mvc;
using TextAlign = Trirand.Web.Mvc.TextAlign;

namespace Models.JqGridModels
{
    public class ParticipantsConferenceJqGridModel
    {
        private readonly UrlHelper _url = new UrlHelper(HttpContext.Current.Request.RequestContext);

        public ParticipantsConferenceJqGridModel()
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
                    },
                    new JQGridColumn
                    {
                        DataField = "FullName",
                        HeaderText = Resources.ParticipantsConference_FullName,
                        Editable = true,
                        Searchable = false,
                        EditClientSideValidators = new List<JQGridEditClientSideValidator> {new RequiredValidator()},
                    },
                    new JQGridColumn
                    {
                        DataField = "FormOfParticipation",
                        HeaderText = Resources.ParticipantsConference_FormOfParticipation,
                        Editable = true,
                        Searchable = false,
                        EditClientSideValidators = new List<JQGridEditClientSideValidator> {new RequiredValidator()},
                    },
                    new JQGridColumn
                    {
                        DataField = "IsHostel",
                        HeaderText = Resources.ParticipantsConference_IsHostel,
                        Editable = true,
                        Searchable = false,
                        Formatter = new CheckBoxFormatter(),
                        TextAlign = TextAlign.Center,
                        Width = 50
                    },
                    new JQGridColumn
                    {
                        DataField = "ArrivalTime",
                        HeaderText = Resources.ParticipantsConference_ArrivalTime,
                        Editable = true,
                        Searchable = false,
                        EditClientSideValidators = new List<JQGridEditClientSideValidator> {new RequiredValidator()},
                    },
                     new JQGridColumn
                    {
                        DataField = "Comment",
                        HeaderText = Resources.ParticipantsConference_Comment,
                        Editable = true,
                        Searchable = false,
                        EditClientSideValidators = new List<JQGridEditClientSideValidator> {new RequiredValidator()},
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
                    ShowSearchToolBar = false,
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
                ID = "ParticipantsConferenceJqGrid",
                //EditUrl = _url.Action("KeyDatesAddEditJsonResult", "JqGrid"),
                DataUrl = _url.Action("ParticipationConferenceDataBindJsonResult", "JqGrid"),
                Width = Unit.Pixel(800)
            };
        }

        public JQGrid OrdersGrid { get; set; }

    }

}