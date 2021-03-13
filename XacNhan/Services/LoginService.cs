using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using XacNhan.Commom;
using XacNhan.IServices;
using XacNhan.Models;

namespace XacNhan.Services
{
    public class LoginService : ILoginServices
    {
        LoginInfo _login = new LoginInfo();
        public Task<string> ConfirmEmail(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<LoginInfo> SignUp(LoginInfo loginInfo)
        {
            try
            {
                LoginInfo loginInfo1 = await this.CheckRecordExistence(loginInfo);
                if (loginInfo1 == null)
                {
                    using (IDbConnection con = new SqlConnection(Global.ConnectiongString))
                    {
                        if (con.State == ConnectionState.Closed) con.Open();

                        var ologininfos = await con.QueryAsync<LoginInfo>("");
                    }
                }
            }
            catch (Exception ex)
            {
                _login.Message = ex.Message;
            }
            return _login;
        }

        private async Task<LoginInfo> CheckRecordExistence(LoginInfo ologinInfo)
        {
            LoginInfo loginInfo = new LoginInfo();
            if (!string.IsNullOrEmpty(ologinInfo.UserName))
            {
                loginInfo = await this.GetLoginUser(ologinInfo.UserName);
                if(loginInfo != null)
                {
                    if (!loginInfo.IsEmailConfirm)
                    {
                        loginInfo.Message = Messege.VerifyMail;
                    }else if (loginInfo.IsEmailConfirm)
                    {
                        loginInfo.Message = Messege.UserAlreadyCreated;
                    }
                }
            }
            return loginInfo;
        }

        private async Task<LoginInfo> GetLoginUser(string userName)
        {
            _login = new LoginInfo();
            using (IDbConnection con = new SqlConnection(Global.ConnectiongString))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                string sSQL = "SELECT *From LoginInfo Where 1=1";
                if (!string.IsNullOrEmpty(userName))
                {
                    sSQL += "AND Username ='" + userName + "'";
                }
                //using Drapper
                var LoginInfos = (await con.QueryAsync<LoginInfo>(sSQL)).ToList();
                if (LoginInfos != null && LoginInfos.Count > 0) _login = LoginInfos.SingleOrDefault();
                else return null;
            }
            return _login;
        }
    }
}
