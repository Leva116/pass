using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using отправка_эл_письма.UsersClasses;
using System.Windows.Forms;
using static отправка_эл_письма.UsersClasses.InfoEmailSending;

namespace отправка_эл_письма
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            textBoxEmail.Text = "task_code_developmnt@list.ru";
            textBoxName.Text = "name";
        }





        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxEmail.Text) ||

                String.IsNullOrWhiteSpace(textBoxName.Text) ||
                    String.IsNullOrWhiteSpace(textBoxBody.Text) ||
                        String.IsNullOrWhiteSpace(textBoxSubject.Text))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }
            string smtp = "smtp.mail.ru";
            StringPair fromInfo = new StringPair("leva.yakimov116@mail.ru", "Лев");
            string password = "Ek3S4vHfvTuJWiviwarv";
            
            StringPair toinfo = new StringPair(textBoxEmail.Text, textBoxName.Text);
            string subject = textBoxSubject.Text;
            string body = $"{DateTime.Now} \n" +
                $"{Dns.GetHostName()} \n" +
                $"{Dns.GetHostAddresses(Dns.GetHostName()).First()} \n" +
                $"{textBoxBody.Text}";

            InfoEmailSending info =
                new InfoEmailSending(smtp, fromInfo, password, toinfo, subject, body);
            SendingEmail sendingEmail = new SendingEmail(info);
            sendingEmail.Send();
            MessageBox.Show("Письмо отправлено!");
            foreach (TextBox textBox in Controls.OfType<TextBox>())
                textBox.Text = "";


        }

        private void textBoxBody_TextChanged(object sender, EventArgs e)
        {

        }
    }



}

