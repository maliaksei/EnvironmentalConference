
using System;
using System.Linq;
using System.Web.Security;
using Membership.Exception;
using Repository;
using Repository.Filters;
using Repository.Repositories;

namespace Membership
{
    public class CustomMembershipProvider : MembershipProvider
    {
        private bool _RequiresUniqueEmail = true;

        private DataManager dataManager = new DataManager();

        public void CreateUser(string surname, string name, string patronymic, string academicDegree, string email, string academicTitle,
            string organization, string address, int phone, string role, string password)
        {
            dataManager.UserRepository.CreateUser(surname, name, patronymic, academicDegree, email, academicTitle, organization, address, phone, role, password);
        }

        public string GetUserFullNameByEmail(string email)
        {
            return dataManager.UserRepository.GetAll().GetUserFullNameByEmail(email);
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer,
            bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion,
            string newPasswordAnswer)
        {
            throw new System.NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new System.NotImplementedException();
        }

        public ChangePasswordException ChangePassword(string username, string oldPassword, string newPassword, bool isUser)
        {
            if (!ValidateUser(username, oldPassword))
            {
                return ChangePasswordException.OldPasswordIncorrect;
            }
            if (string.IsNullOrEmpty(newPassword.Trim()))
            {
                return ChangePasswordException.NewPasswordNotNull;
            }
            return dataManager.UserRepository.ChangePassword(username, newPassword)
                ? ChangePasswordException.Succses
                : ChangePasswordException.ChangePasswordError;
        }



        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new System.NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new System.NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new System.NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            if (string.IsNullOrEmpty(password.Trim()) || string.IsNullOrEmpty(username.Trim()))
                return false;

            string hash = FormsAuthentication.HashPasswordForStoringInConfigFile(password.Trim(), "md5");

            return dataManager.UserRepository.GetAll().Any(user => (user.Email == username.Trim()) && (user.Password == hash));
        }

        public override bool UnlockUser(string userName)
        {
            throw new System.NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new System.NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new System.NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new System.NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new System.NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new System.NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new System.NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new System.NotImplementedException();
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new System.NotImplementedException(); }
        }

        public override bool EnablePasswordReset
        {
            get { throw new System.NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new System.NotImplementedException(); }
        }

        public override string ApplicationName { get; set; }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new System.NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new System.NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get
            {
                return _RequiresUniqueEmail;
            }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new System.NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new System.NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new System.NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}
