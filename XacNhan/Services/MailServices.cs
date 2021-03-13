using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using XacNhan.IServices;
using XacNhan.Models;
using XacNhan.Commom;

namespace XacNhan.Services
{
    public class MailServices : IMailServices
    {
        public string GetMailBody(LoginInfo loginInfo)
        {
            string url = Global.DomainName + "api/LoginInfo/Confirm?username=" + loginInfo.UserName;
            return string.Format(@"<div style='text-align:center;'>
                                    <h1>Welcome to our Web Site</h1>
                                    <h3>Click below button for verify your Email Id</h3>
                                    <form method='post' action='{0}' style='display: inline;'>
                                      <button type = 'submit' style=' display: block;
                                                                    text-align: center;
                                                                    font-weight: bold;
                                                                    background-color: #008CBA;
                                                                    font-size: 16px;
                                                                    border-radius: 10px;
                                                                    color:#ffffff;
                                                                    cursor:pointer;
                                                                    width:100%;
                                                                    padding:10px;'>
                                        Confirm Mail
                                      </button>
                                    </form>
                                </div>", url, loginInfo.UserName);
        }

        public async Task<string> SendMail(MailClass mailClass)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(mailClass.FromMailId);
                    mailClass.ToMailIds.ForEach(x =>
                    {
                        mail.To.Add(x);
                    });
                    mail.Subject = mailClass.Subject;
                    mail.Body = mailClass.Body;
                    mail.IsBodyHtml = mailClass.isBodyhtml;
                    mailClass.Attachment.ForEach(x =>
                    {
                        mail.Attachments.Add(new Attachment(x));
                    });
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new System.Net.NetworkCredential(mailClass.FromMailId, mailClass.FromMailIdPassword);
                        smtp.EnableSsl = true;
                        await smtp.SendMailAsync(mail);
                        return Messege.SentMail;
                    }
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}
