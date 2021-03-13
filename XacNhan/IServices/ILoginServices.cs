using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XacNhan.Models;

namespace XacNhan.IServices
{
    public interface ILoginServices
    {
         Task<LoginInfo> SignUp(LoginInfo loginInfo);
         Task<string> ConfirmEmail(string username);
    }
}
