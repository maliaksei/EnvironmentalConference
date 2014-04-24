using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom.Data;
using System.Web.Security;

namespace Repository.Repositories
{
    public class UserRepository : IRepository<Users>
    {
        #region Memebers

        protected readonly ECDatabaseEntities _dataContext;

        private const string TooManyUser = "User already exists";

        #endregion

        #region Constructors

        public UserRepository()
        {
            this._dataContext = new ECDatabaseEntities();
        }

        #endregion

        #region Override Methods
        public override IQueryable<Users> GetAll()
        {
            return _dataContext.Users;
        }

        public override Users Add(Users entity)
        {
            if (UserExists(entity))
            {
                throw new ArgumentException(TooManyUser);
            }
            _dataContext.Users.Add(entity);
            _dataContext.SaveChanges();
            return entity;
        }

        public override void Update(Users entity)
        {
            var user = _dataContext.Users.SingleOrDefault(x => x.Email == entity.Email);
            if (user != null)
            {
                user.Application = entity.Application;
                _dataContext.SaveChanges();
            }

        }

        public override bool Delete(Users entity)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private Methods

        private bool UserExists(Users user)
        {
            return user != null && _dataContext.Users.Any(x => x.Email == user.Email || x.UserId == user.UserId);
        }

        #endregion

        #region Public Methods

        public void CreateUser(string surname, string name, string patronymic, string academicDegree, string email, string academicTitle,
            string organization, string address, int phone, string role, string password)
        {
            var userRole = _dataContext.UserRoles.SingleOrDefault(x => x.Role == role);

            if (string.IsNullOrEmpty(surname.Trim()))
                throw new ArgumentException("The surname name provided is invalid. Please check the value and try again.");
            if (string.IsNullOrEmpty(name.Trim()))
                throw new ArgumentException("The name provided is invalid. Please check the value and try again.");
            if (string.IsNullOrEmpty(patronymic.Trim()))
                throw new ArgumentException("The patronymic provided is invalid. Please check the value and try again.");
            if (string.IsNullOrEmpty(academicDegree.Trim()))
                throw new ArgumentException("The academic degree provided is invalid. Please check the value and try again.");
            if (string.IsNullOrEmpty(email.Trim()))
                throw new ArgumentException("The email provided is invalid. Please check the value and try again.");
            if (string.IsNullOrEmpty(academicTitle.Trim()))
                throw new ArgumentException("The academic title is invalid. Please check the value and try again.");
            if (string.IsNullOrEmpty(organization.Trim()))
                throw new ArgumentException("The organization is invalid. Please check the value and try again.");
            if (string.IsNullOrEmpty(address.Trim()))
                throw new ArgumentException("The address is invalid. Please check the value and try again.");
            if (phone <= 0)
                throw new ArgumentException("The phone is invalid. Please enter a valid phone number.");
            if (string.IsNullOrEmpty(password.Trim()))
                throw new ArgumentException("The password provided is invalid. Please enter a valid password value.");
            if (userRole == null)
                throw new ArgumentException("The role selected for this user does not exist! Contact an administrator!");
            if (_dataContext.Users.Any(user => user.Email == email))
                throw new ArgumentException("Данный email адрес уже зарегистрирован в системе. Введите другой email.");

            var newUser = new Users
            {
                UserId = Guid.NewGuid(),
                Surname = surname,
                Name = name,
                Patronymic = patronymic,
                AcademicDegree = academicDegree,
                Email = email,
                AcademicTitle = academicTitle,
                Organization = organization,
                Address = address,
                Phone = phone,
                RoleId = userRole.UserRoleId,
                Password = FormsAuthentication.HashPasswordForStoringInConfigFile(password.Trim(), "md5"),
            };
            try
            {
                Add(newUser);
            }
            catch (ArgumentException ae)
            {
                throw ae;
            }
            catch (Exception e)
            {
                throw new ArgumentException("The authentication provider returned an error. Please verify your entry and try again. " +
                    "If the problem persists, please contact your system administrator.");
            }
        }

        public bool ChangePassword(string username, string newPassword)
        {
            var user = _dataContext.Users.SingleOrDefault(x => x.Email == username);
            string hash = FormsAuthentication.HashPasswordForStoringInConfigFile(newPassword.Trim(), "md5");
            if (user != null)
            {
                user.Password = hash;
                _dataContext.SaveChanges();
                return true;
            }
            return false;
        }



        #endregion
    }
}
