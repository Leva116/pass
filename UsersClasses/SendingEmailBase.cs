using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace отправка_эл_письма.UsersClasses
{
    public class SendingEmailBase
    {
        private InfoEmailSending InfoEmailSending {  get; set; }
        public void Send()
        {
            try
            {
                SmtpClient mySmtpClient =
                     new SmtpClient(InfoEmailSending.SmtpClientAdress);

                mySmtpClient.UseDefaultCredentials = false;
                mySmtpClient.EnableSsl = true;
                NetworkCredential basicAuthentificationInfo = new
                     NetworkCredential(
                 InfoEmailSending.EmailAdressFrom.EmailAdress,
                 InfoEmailSending.EmailPassword);

                mySmtpClient.Credentials = basicAuthentificationInfo;

                MailAddress from = new MailAddress(
                InfoEmailSending.EmailAdressFrom.EmailAdress,
                InfoEmailSending.EmailAdressFrom.Name);

                MailAddress to = new MailAddress(
                InfoEmailSending.EmailAdressFrom.EmailAdress,
                InfoEmailSending.EmailAdressFrom.Name);

                MailMessage myMail = new MailMessage(from, to);

                MailAddress replyTo =
                new MailAddress(InfoEmailSending.EmailAdressFrom.EmailAdress);
                myMail.ReplyToList.Add(replyTo);

                Encoding encoding = Encoding.UTF8;

                myMail.Subject = InfoEmailSending.Subject;
                myMail.SubjectEncoding = encoding;


                myMail.Body = InfoEmailSending.Body;
                myMail.BodyEncoding = encoding;

                mySmtpClient.Send(myMail);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}