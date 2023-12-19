using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace отправка_эл_письма.UsersClasses
{
    public class InfoEmailSending
    {
        //public InfoEmailSending(string smtp, StringPair fromInfo, string password, string subject, string body)
        //{
        //    Subject = subject;
        //    Body = body;
        //}

        public InfoEmailSending(string smtpClientAdress,
               StringPair emailAdressFrom,
               string emailPassword,
                StringPair emailAdressTo,
                string subject,
                string body)
              {
                    SmtpClientAdress = string.IsNullOrWhiteSpace(smtpClientAdress) ?
                    throw new Exception("нельзя вставлять пробелы или пустое значение!") :
                   smtpClientAdress;

                    EmailAdressFrom = emailAdressFrom ?? throw new ArgumentNullException(nameof(emailAdressFrom));

                    EmailPassword = string.IsNullOrWhiteSpace(emailPassword) ?
                  throw new Exception("нельзя вставлять пробелы или пустое значение!") :
                   emailPassword;

                   EmailAdressTo = emailAdressTo ?? throw new ArgumentNullException(nameof(emailAdressTo));

                  Subject = subject ?? throw new ArgumentNullException(nameof(subject));
                  Body = body ?? throw new ArgumentNullException(nameof(body));


              }

        public string SmtpClientAdress { get; set; }
        public StringPair EmailAdressFrom { get; set; }
        public string EmailPassword { get; set; }
        public StringPair EmailAdressTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

    }
        public class StringPair
        {
            public StringPair(string emailAdress, string name )
            {
            EmailAdress = String.IsNullOrWhiteSpace(emailAdress) ?
                throw new Exception("нельзя вставлять пробелы или пустое значение!") :
                    emailAdress;
            Name = String.IsNullOrWhiteSpace(name) ?
            throw new Exception("нельзя вставлять пробелы или пустое значение!") :
                name;
            }
            public string EmailAdress { get; set; }
            public string Name { get; set; }

        }

    
}
