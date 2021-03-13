using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XacNhan.Models;

namespace XacNhan.IServices
{
    public interface IMailServices
    {
        Task<string> SendMail(MailClass mailClass);
        string GetMailBody(LoginInfo loginInfo);
    }
}
