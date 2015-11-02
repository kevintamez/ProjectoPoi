using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mime;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Net;
using System.Threading;

namespace TCPChatCliente
{
    public partial class Correo : Form
    {
        public Thread th1;
        static frmSplash splash;
        const int kSplashUpdateInterval_ms = 1;
      bool loading = true;
        string archivoAdjunto;
        public Correo()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            openFileDialog1.ShowDialog();
            archivoAdjunto = openFileDialog1.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread splashThread = new Thread(new ThreadStart(StartSplash));
            splashThread.Start();
            this.SendToBack();
            textBoxError.Visible = false;
            textBoxError.Text = "";
            string contraseña = textBoxContraseña.Text;
            string de = textBoxDe.Text;
            string para = textBoxPara.Text;
            string asunto = textBoxAsunto.Text;
            string mensaje = textBoxMensaje.Text;


            //MailMessage message = new MailMessage(de, para, asunto, mensaje);
            MailMessage message = new MailMessage();
            message.To.Add(para);
            message.From = new MailAddress(de , de, System.Text.Encoding.UTF8);
            message.Subject = asunto;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.Body = mensaje;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = false;

            if (archivoAdjunto != null)
            {
                Attachment data = new Attachment(archivoAdjunto, MediaTypeNames.Application.Octet);
                ContentDisposition disposition = data.ContentDisposition;
                disposition.CreationDate = System.IO.File.GetCreationTime(archivoAdjunto);
                disposition.ModificationDate = System.IO.File.GetLastWriteTime(archivoAdjunto);
                disposition.ReadDate = System.IO.File.GetLastAccessTime(archivoAdjunto);
                message.Attachments.Add(data);
            }

            SmtpClient client = new SmtpClient();

            if (textBoxDe.Text.Contains("@hotmail.com"))
            {

                //  new SmtpClient("smtp-mail.outlook.com", 25);
                //client.Host = "smtp-mail.outlook.com";
                client.Credentials = new NetworkCredential(de, contraseña);
                client.Host = "smtp-mail.outlook.com";
                client.Port = 587;
                client.EnableSsl = true;
            }
            if (textBoxDe.Text.Contains("@gmail.com"))
            {
                client.Credentials = new NetworkCredential(de, contraseña);
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;
            }
            try
            {
               
                client.Send(message);
                loading = false;
                this.BringToFront();
                textBoxError.Visible = true;
                textBoxError.Text = "Correo enviado exitosamente!";
                CloseSplash();
            }

            catch (System.Net.Mail.SmtpException ex)
            {
                
                textBoxError.Text = ex.Message;
                textBoxError.Visible = true;
               loading = false;
               this.BringToFront();
               CloseSplash();
            }
        }

        private void Correo_Load(object sender, EventArgs e)
        {
            //pictureBox1.Visible = false;
            this.BringToFront();
        }
        static public void StartSplash()
        {
            // Instance a splash form given the image names
            splash = new frmSplash();

            // Run the form
            Application.Run(splash);
        }
        private void CloseSplash()
        {
            if (splash == null)
                return;

            // Shut down the splash screen
            splash.Invoke(new EventHandler(splash.KillMe));
            splash.Dispose();
            splash = null;
        } 
//      private void Loading()
//{
//    while(loading)
//    {
//        pictureBox1.Visible = true; //Display loading message here.
//    }
//}
      
}
    }

