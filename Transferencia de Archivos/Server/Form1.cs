using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//Nuestra libreria dll
using POI;
using System.IO;

namespace Server
{
    public partial class Servidor : Form
    {

        POI.Server _serverSocket;

        public Servidor()
        {
            InitializeComponent();
            _serverSocket = new POI.Server();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //_serverSocket.startServer();
        }

        

        private void lvClient_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(_serverSocket._isReady)
            {
                MemoryStream ms = new MemoryStream(_serverSocket._imageData);
                Image image = Image.FromStream(ms);

                pbServer.Image = image;
                _serverSocket._isReady = false;
            }

            //foreach (POI.Client c in _serverSocket._clients)
            //{
            //    bool exist = false;

            //    foreach (ListViewItem lvi in lvClient.Items)
            //    {
            //        String currentName = lvi.Name;
            //        if (currentName == c.clientName)
            //        {
            //            exist = true;
            //            break;
            //        }
            //    }

            //    if (!exist)
            //    {
            //        ListViewItem lvi = new ListViewItem(c.clientName);
            //        lvi.Name = c.clientName;
            //        lvClient.Items.Add(lvi);
            //    }
            //}
        }

        private void Servidor_Load(object sender, EventArgs e)
        {

        }
    }
}
