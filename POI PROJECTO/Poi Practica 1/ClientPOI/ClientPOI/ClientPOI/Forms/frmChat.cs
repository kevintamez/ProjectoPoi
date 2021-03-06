﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using ClientPOI.USER;
using ClientPOI.SERVER;
using System.Threading;
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.Configuration;
using System.Web;
using System.Net.NetworkInformation;
namespace ClientPOI
{
    public partial class frmChat : Form
    {
        Server server;
        User MyUser;
        Thread waitingMessage;
        bool chatOn;
        public static int DEFAULT_PORT = 12345;

        public static String SERVER_ADRESS = "192.168.0.166";

        public frmChat()
        {

            server = new Server();
            waitingMessage = new Thread(new ThreadStart(WaittingMessage));
            chatOn = true;

            InitializeComponent();
            
        }
        public frmChat(string _Name, string _State, string _IP)
        {
            MyUser = new User();
            MyUser.userName = _Name;
            switch (_State) { 
                case "Connected":
                    MyUser.userState = UserState.Connected;
                    break;
                case "Absent":
                    MyUser.userState = UserState.Absent;
                    break;
                case "Busy":
                    MyUser.userState = UserState.Busy;
                    break;
            }
            server = new Server();
            server.IP = _IP;
            waitingMessage = new Thread(new ThreadStart(WaittingMessage));
            chatOn = true;
            InitializeComponent();

        }

        /*
        public class TransparentTextBox : RichTextBox
        {
            public TransparentTextBox()
            { }

            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams TransparentTextBoxParams = base.CreateParams;

                    //0x20 for transparent style 
                    TransparentTextBoxParams.ExStyle |= 0x20;
                    return TransparentTextBoxParams;
                }
            }

            protected override void OnPaintBackground(PaintEventArgs pevent)
            {
                //We dont want to paint anything in the back ground.
                //base.OnPaintBackground(pevent);
                //Do nothing
            }


            protected override void WndProc(ref Message message)
            {
                // Supress the below events (To hide the blinking caret in the RichTextBox)
                // WM_NCLBUTTONDOWN WM_LBUTTONUP WM_LBUTTONDOWN 
                // WM_LBUTTONDBLCLK WM_RBUTTONDOWN WM_RBUTTONUP WM_RBUTTONDBLCLK  
                if (!(base.ReadOnly &&
                      (message.Msg == 0xa1 ||
                       message.Msg == 0x201 ||
                       message.Msg == 0x202 ||
                       message.Msg == 0x203 ||
                       message.Msg == 0x204 ||
                       message.Msg == 0x205 ||
                       message.Msg == 0x206)))
                    base.WndProc(ref message);
            }
        }
        */

        private void frmChat_Load(object sender, EventArgs e)
        {
            launchClient();
            
        }

        public void WaittingMessage() {

            while (chatOn)
            {
                server.serverData = new byte[1024];
                server.serverRecv = 0;
                server.serverStringData = "";
                server.serverRecv = server.serverSocket.Receive(server.serverData);

                server.serverStringData = Encoding.ASCII.GetString(server.serverData, 0, server.serverRecv);
                if (server.serverStringData != "")
                {
                    this.SetText(server.serverStringData);

             
                }
            }
        }
        private void launchClient() {
            //End Point del cliente
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(SERVER_ADRESS),
                DEFAULT_PORT);
            //Creacion del Socket
            server.serverSocket = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
            try
            {
                //Tratar de conectarse al servidor con el EndPoint
                server.serverSocket.Connect(ipep);
            }
            catch (SocketException e)
            {
                //Mostrar error sino se logra
                MessageBox.Show("Imposible conectar con el servidor" + Environment.NewLine + e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            server.sendUserDescription(MyUser.userName, MyUser.userState.ToString());
            waitingMessage.Start();
            //Recibir la informacin del servidor si se logro
            /*
            server.serverRecv = server.serverSocket.Receive(server.serverData);
            //Transformar la informacon a String
            server.serverStringData = Encoding.ASCII.GetString(server.serverData, 0, server.serverRecv);
            //Imprimir la informacion
            txtChat.Text = server.serverStringData;
             * */
            /*
            Console.WriteLine("Desconectando del servidor...");
            //Apaga servidor y cliente
            server.serverSocket.Shutdown(SocketShutdown.Both);
            //Cierra conexion
            server.serverSocket.Close();
            */
            
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            
            server.serverInput = MyUser.userName + ": " + txtMessage.Text + "\n";
            server.sendMessage();
            //txtChat.AppendText(Environment.NewLine + server.serverStringData);
            txtMessage.Text = "";
            txtMessage.Focus();    
        }

   

        private void frmChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                server.serverSocket.Send(Encoding.ASCII.GetBytes("exit"));
                chatOn = false;
            }
            catch (SocketException se) {
                //Mostrar error sino se logra
                //MessageBox.Show("Imposible conectar con el servidor" + Environment.NewLine + se.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if(waitingMessage.IsAlive)
                waitingMessage.Join();
            Application.Exit();
        }



        private void txtChat_VisibleChanged(object sender, EventArgs e)
        {
            //txtChat.ScrollToCaret();
        }

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (this.rTBChat.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.rTBChat.AppendText(text);
                this.rTBChat.SelectionStart = this.rTBChat.Text.Length;
                this.rTBChat.ScrollToCaret();
                label1.Text = new Ping().Send(SERVER_ADRESS).RoundtripTime.ToString() + "ms";
            }
        }

       


        public delegate void SetTextCallback(string message);




        public static bool SetStyle(Control c, ControlStyles Style, bool value)
        {
            bool retval = false;
            Type typeTB = typeof(Control);
            System.Reflection.MethodInfo misSetStyle = typeTB.GetMethod("SetStyle", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (misSetStyle != null && c != null) { misSetStyle.Invoke(c, new object[] { Style, value }); retval = true; }
            return retval;
        }



        private void rTBChat_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnZumbido_Click(object sender, EventArgs e)
        {
        }
       

    }
}
