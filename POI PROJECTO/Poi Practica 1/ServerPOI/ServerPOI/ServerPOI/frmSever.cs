using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServerPOI.USER;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using ServerPOI.FW;
//using ServerPOI.Conection;


namespace ServerPOI
{
    public partial class frmSever : Form
    {

        public List<User> Client;
        Socket serverSocket;
        Thread waitClient;
        bool serverOn;
        public static int DEFAULT_PORT = 12345;
        //public static IPEndPoint SERVER_ENDPOINT new IPEndPoint(IPAddress.Parse(148.234.88.63))
        public static String SERVER_ADRESS = "192.168.0.166";
        public int countClient = 0;
        public frmSever()
        {
            Client = new List<User>();
            InitializeComponent();
            waitClient = new Thread(new ThreadStart(WaitingClient));
            serverOn = true;
        }

        private void frmSever_Load(object sender, EventArgs e)
        {
            Client.Add(new User());
            waitClient.Start();
        }

        private void WaitingClient(){
            byte[] data = new byte[1024];
            
            //Creacion de End Point IPAdress cualquiera y el Puerto
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any,DEFAULT_PORT
                /*FALTA*/);
            //Creacion del scoket
            serverSocket = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
            //Se agrega en Endpoint al scoket
            serverSocket.Bind(ipep);
            
            while (serverOn)
            {
                
                //Este esperando 10 ms
                serverSocket.Listen(10);
                this.SetText("Esperando por un cliente...\n");
                //txtLog.AppendText("Esperando por un cliente...\n");
                //Iniciar Cliente
                try
                {
                    Client[countClient].startClient(serverSocket.Accept(), countClient,this);
                    //Creacion del endpoint del cliente
                    Client[countClient].userEP = (IPEndPoint)Client[countClient].userSocket.RemoteEndPoint;

                    this.SetText("Concentando con " + Client[countClient].userEP.Address + " por el puerto " +
                        Client[countClient].userEP.Port + "\n");
                    /*
                    //Bienvenida
                    string welcome = "Bienvenido al servidor de prueba. \n";
                    //Convertir bienvenida a bytes
                    data = Encoding.ASCII.GetBytes(welcome);
                    //Enviar al cliente la informacion, Informacion y tamaño
                    Client[countClient].userSocket.Send(data, data.Length, SocketFlags.None);
                    */
                    countClient++;
                    Client.Add(new User());
                }
                catch (SocketException e) {
                    e.ToString();
                }
                Thread.Sleep(0);
            }
        }

        private void CloseServer() {
            
            //Desconectar del cliente
            //Cerrar coneccion con el cliente
            for (int i = 0; i < countClient; i++) {
                Client[i].serverOn = false;
            }
            //Cerrar socket
            serverSocket.Close();
            waitClient.Join();
            Application.Exit();
        }

        private void frmSever_FormClosing(object sender, FormClosingEventArgs e)
        {
            serverOn = false;
            CloseServer();
        }

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (this.txtLog.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txtLog.AppendText(text);
            }
        }

        public delegate void SetTextCallback(string message);

        //private void testconection_Click(object sender, EventArgs e)
        //{
        //    //Connection.con();   
        //}
    }
}
