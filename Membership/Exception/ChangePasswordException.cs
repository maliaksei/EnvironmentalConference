using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Exception
{
    public enum ChangePasswordException
    {
        Succses = 0,
        OldPasswordIncorrect = 1,
        NewPasswordNotNull = 2, 
        ChangePasswordError = 3
    }
}
