using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
namespace TCPChatCliente
{
    public partial class Stmpcs : Form
    {
        public Stmpcs()
        {
            InitializeComponent();
            this.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog sf = new OpenFileDialog();
            sf.InitialDirectory = "C:\\";
            sf.FileName = "";

            if (sf.ShowDialog() == DialogResult.OK)
            {
                txt_attachment.Text = sf.FileName;
            }
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(txt_account.Text, "Chat", System.Text.Encoding.UTF8);
                msg.To.Add(new MailAddress(txt_to.Text));
                msg.To.Add(new MailAddress(txt_account.Text));
               
                msg.Subject = txt_subject.Text;
                //Formato de codificación del Asunto
                msg.SubjectEncoding = System.Text.Encoding.UTF8;
               
                msg.Body = txt_message.Text;
                //Se establece la codificación del Cuerpo
                msg.BodyEncoding = System.Text.Encoding.Unicode;

                   
                        msg.Attachments.Add(new Attachment(txt_attachment.Text));
                    

             

                try
                {
                    SmtpClient smtp = new SmtpClient();
                   // smtp.Host = "smtp.gmail.com";
                    //---para outlook.com
                    smtp.Host = "smtp.live.com";
                    smtp.Port = 587;
                    //smtp.Port = 465;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential(txt_account.Text, txt_password.Text);

                    try
                    {
                        smtp.Send(msg);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Aqui fallo");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ToggleBold_Click(object sender, EventArgs e)
        {
            if (txt_message.SelectionFont != null)
            {
                System.Drawing.Font currentFont = txt_message.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if (txt_message.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Bold;
                }

                txt_message.SelectionFont = new Font(
                   currentFont.FontFamily,
                   currentFont.Size,
                   newFontStyle
                );
            }
        }

        private void FonSizeMas_Click(object sender, EventArgs e)
        {
            System.Drawing.Font currentFont = txt_message.SelectionFont;
            txt_message.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size + 4);
        }

        private void FontSizeMenos_Click(object sender, EventArgs e)
        {
            System.Drawing.Font currentFont = txt_message.SelectionFont;
            txt_message.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size - 4);
        }

        private void btn_browse_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog sf = new OpenFileDialog();
            sf.InitialDirectory = "C:\\";
            sf.FileName = "";

            if (sf.ShowDialog() == DialogResult.OK)
            {
                txt_attachment.Text = sf.FileName;
            }
        }

        private void txt_account_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
