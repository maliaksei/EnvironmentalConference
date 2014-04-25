using System;
using System.ComponentModel.DataAnnotations;
using Models.Properties;

namespace Models.ViewModels.UserAccount
{
    public class UserInfoViewModel
    {
        public Guid UserId { get; set; }

        [Display(Name = "Surname", ResourceType = typeof(Resources))]
        public string Surname { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Resources))]
        public string Name { get; set; }

        [Display(Name = "Patronymic", ResourceType = typeof(Resources))]
        public string Patronymic { get; set; }

        [Display(Name = "AcademicDegree", ResourceType = typeof(Resources))]
        public string AcademicDegree { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Resources))]
        public string Email { get; set; }

        [Display(Name = "AcademicTitle", ResourceType = typeof(Resources))]
        public string AcademicTitle { get; set; }

        [Display(Name = "Organization", ResourceType = typeof(Resources))]
        public string Organization { get; set; }

        [Display(Name = "Address", ResourceType = typeof(Resources))]
        public string Address { get; set; }

        [Display(Name = "Phone", ResourceType = typeof(Resources))]
        public string Phone { get; set; }
    }
}
