using System.ComponentModel.DataAnnotations;
using WebSite.Properties;

namespace WebSite.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
    }

    public class ManageUserViewModel
    {
        [Display(Name = "OldPassword", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = "FieldRequired")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources),
                          ErrorMessageResourceName = "FieldLong")]
        public string OldPassword { get; set; }


        [Display(Name = "NewPassword", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                   ErrorMessageResourceName = "FieldRequired")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources),
                         ErrorMessageResourceName = "FieldLong")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }


        [Display(Name = "ConfirmPassword", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = "FieldRequired")]
        [Compare("NewPassword", ErrorMessageResourceName = "PasswordCompare", ErrorMessageResourceType = typeof(Resources))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources),
                   ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "Email", ResourceType = typeof(Resources))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources),
                   ErrorMessageResourceName = "FieldRequired")]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources))]
        public string Password { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(Resources))]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources),
                    ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "Surname", ResourceType = typeof(Resources))]
        public string Surname { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources),
                   ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "Name", ResourceType = typeof(Resources))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources),
                   ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "Patronymic", ResourceType = typeof(Resources))]
        public string Patronymic { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources),
                   ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "AcademicDegree", ResourceType = typeof(Resources))]
        public string AcademicDegree { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources),
                   ErrorMessageResourceName = "FieldRequired")]
        [EmailAddress(ErrorMessage = "Email адрес некорректен.")]
        [Display(Name = "Email", ResourceType = typeof(Resources))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources),
                   ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "AcademicTitle", ResourceType = typeof(Resources))]
        public string AcademicTitle { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources),
                   ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "Organization", ResourceType = typeof(Resources))]
        public string Organization { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources),
                    ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "Address", ResourceType = typeof(Resources))]
        public string Address { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources),
                   ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "Phone", ResourceType = typeof(Resources))]
        public int Phone { get; set; }

        //[Required]
        //[Display(Name = "Role")]
        //public string Role { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources),
                    ErrorMessageResourceName = "FieldRequired")]
        [StringLength(100, ErrorMessageResourceType = typeof(Resources),
                          ErrorMessageResourceName = "FieldMinLong", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Resources))]
        [Compare("Password", ErrorMessageResourceName = "PasswordCompare", ErrorMessageResourceType = typeof(Resources))]
        public string ConfirmPassword { get; set; }
    }
}
