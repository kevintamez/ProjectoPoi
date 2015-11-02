using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Necesarias para el envio de correo por SMTP
using System.Web;
using System.Net;
using System.Net.Mail;

namespace SMTP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            sendMail();
        }

        public void sendMail()
        {
            String from = txtFrom.Text;
            String to = txtTo.Text;
            String subject = txtSubject.Text;
            String body = txtBody.Text;
            String smtpClient = txtSMTPClient.Text;
            String username = txtUsername.Text;
            String password = txtPassword.Text;

            if(from == "" || to == "" || subject == "" || body == "")
            {
                MessageBox.Show("Faltan campos!");
                return;
            }

            MailMessage mail = new MailMessage(from, to, subject, body);

            //Ej: smtp.gmail.com por el puerto 587
            SmtpClient client = new SmtpClient(smtpClient, 587); //SMTP cliente, Puerto

            //Ej: pruebas@gmailcom; pass465421;
            client.Credentials = new NetworkCredential(username, password);

            client.EnableSsl = true;
            client.Send(mail);
            MessageBox.Show("Correo enviado!!!");
        }
    }
}
