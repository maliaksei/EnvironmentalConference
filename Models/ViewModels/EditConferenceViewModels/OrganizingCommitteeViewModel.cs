using System.ComponentModel.DataAnnotations;
using Models.JqGridModels;
using Models.Properties;

namespace Models.ViewModels.EditConferenceViewModels
{
    public class OrganizingCommitteeViewModel
    {
        public OrganizingCommitteeViewModel()
        {
            OrganizingCommitteeMembers = new OrganizingCommitteeMembersJqGridModel();
        }

        public int OrganizingCommitteeId { get; set; }

        [Display(Name = "OrganizingCommittee_Address", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "FieldRequired")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "FieldLong")]
        public string Address { get; set; }

        [Display(Name = "OrganizingCommittee_Email", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "FieldRequired")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "FieldLong")]
        [EmailAddress( ErrorMessageResourceName = "EmailAdressNotValid",ErrorMessageResourceType = typeof(Resources), ErrorMessage = null)]
        public string Email { get; set; }

        [Display(Name = "OrganizingCommittee_Phone", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "FieldRequired")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "FieldLong")]
        public string Phone { get; set; }

        public OrganizingCommitteeMembersJqGridModel OrganizingCommitteeMembers { get; set; }
    }
}
