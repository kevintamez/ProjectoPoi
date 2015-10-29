using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ClientPOI.SERVER;
using ClientPOI.USER;
using System.IO;

namespace ClientPOI.Forms
{
    public partial class frmChatGrupal : Form
    {
        Server server;
        User myUser;
        Hashtable emoticonos;

        
        public frmChatGrupal()
        {
            InitializeComponent();
        }

        public frmChatGrupal(string grupo, string usuario)
        {
            //frmChatGrupal chatgrupal = new frmChatGrupal();
            //chatgrupal.Name = grupo;

            InitializeComponent();
        }

        private void cBState_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        public void AgregarEmoticonos()
        {
            foreach (string EmotiParam in emoticonos.Keys)
            {
                while (ListMsg.Text.Contains(EmotiParam))
                {
                    int emot = ListMsg.Text.IndexOf(EmotiParam);
                    ListMsg.Select(emot, EmotiParam.Length);
                    try

                    {
                        Clipboard.SetImage((Image)emoticonos[EmotiParam]);
                        ListMsg.Paste();
                    }
                    catch { }
                }
            }

        }


        public void DibujaEmoti()

        {

            emoticonos = new Hashtable(16);
            emoticonos.Add(":(", Properties.Resources.triste);
            emoticonos.Add(":3", Properties.Resources.aliviado);
            emoticonos.Add(":S", Properties.Resources.asco);
            emoticonos.Add(":*", Properties.Resources.beso);
            emoticonos.Add("u.u", Properties.Resources.desanimado);
            emoticonos.Add("<3", Properties.Resources.enamorado);
            emoticonos.Add("-.-", Properties.Resources.fastidiado);
            emoticonos.Add(":D", Properties.Resources.feliz);
            emoticonos.Add(";)", Properties.Resources.guiño);
            emoticonos.Add(":'(", Properties.Resources.lagrima);
            emoticonos.Add("n_n", Properties.Resources.jijitl);
            emoticonos.Add(":P", Properties.Resources.lengua);
            emoticonos.Add(":DD", Properties.Resources.MuyFeliz);
            emoticonos.Add("3:)", Properties.Resources.pícaro);
            emoticonos.Add(":)", Properties.Resources.sonrisa);
            emoticonos.Add(":$", Properties.Resources.sonrojado);


        }


        private void frmChatGrupal_Load(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //server.serverInput = MyUser.userName + ": " + txtMessage.Text + "\n";
            //server.sendMessage();
            ////txtChat.AppendText(Environment.NewLine + server.serverStringData);
            //txtMessage.Text = "";
            //txtMessage.Focus();
        }

        private void btnArchivo_Click(object sender, EventArgs e)
        {
            //openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "JPG|*.jpg";
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                textBox2.Text = openFileDialog1.SafeFileName;
                // Convierte la imagen a un string de datos. Serializar
                string imageAsString = ImageToString(openFileDialog1.FileName);

                // Regresa una imagen a partir de un string Deserializar
                Image image = StringToImage(imageAsString);

            }
            
        }

        public string ImageToString(string path)

        {
            try
            {
                if (path == null)

                    throw new ArgumentNullException("path");

                Image im = Image.FromFile(path);

                MemoryStream ms = new MemoryStream();

                im.Save(ms, im.RawFormat);

                byte[] array = ms.ToArray();

                return Convert.ToBase64String(array);
            }
            catch (Exception e)
            {
                e.ToString();
                throw;
            }
            

        }

        public Image StringToImage(string imageString)

        {

            if (imageString == null)

                throw new ArgumentNullException("imageString");

            byte[] array = Convert.FromBase64String(imageString);

            Image image = Image.FromStream(new MemoryStream(array));

            return image;

        }
    }
}
