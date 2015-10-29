using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using POI;

namespace Client
{
    public partial class Cliente : Form
    {

        POI.Client _client;

        OpenFileDialog openFileDialog1 = new OpenFileDialog();

        public Cliente()
        {
            InitializeComponent();

            _client = new POI.Client();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            //String name = txtName.Text;
            //_client.Connect(name);
            _client.connect();
        }

        private void btnEnviarImagen_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            Bitmap bmp = new Bitmap(openFileDialog1.FileName);

            Image image = (Image) bmp;

            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            int imageSizeInt = ms.ToArray().Length;

            byte[] imageSize = Encoding.Default.GetBytes(imageSizeInt.ToString());

            _client.sendImage(imageSize);
            _client.sendImage(ms.ToArray());
        }

        private void Cliente_Load(object sender, EventArgs e)
        {

        }
    }
}
