using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Para usar sockets
using System.Net;
using System.Net.Sockets;

//Para crear hilos
using System.Threading;
using System.Threading.Tasks;

namespace POI
{
    public class Server
    {

        public static String Server_IP = "127.0.0.0";
        public static int PORT = 12345;
        public IPEndPoint SERVER_ENDPOINT = new IPEndPoint(IPAddress.Parse(Server_IP), PORT);

        private Socket _serverSocket;

        public byte[] _imageData;

        public bool _isReady;

        public Server()
        {
            _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void listening()
        {
            _serverSocket.Bind(SERVER_ENDPOINT);
            _serverSocket.Listen(50);

            new Thread(() =>
            {
                while (true)
                {
                    Socket clientSocket = _serverSocket.Accept();

                    byte[] imageSizeBytes = new byte[4];
                    clientSocket.Receive(imageSizeBytes);

                    int imageSize = BitConverter.ToInt32(imageSizeBytes, 0);
                    _imageData = new byte[imageSize];
                    clientSocket.Receive(_imageData);
                    _isReady = true;
                }
            }).Start();


        }

        ////Cosas necesarias
        //public static int DEFAULT_PORT = 12345;
        //public static String SERVER_ADDRESS = "192.168.43.141"; //Profe - 192.168.43.106
        //public static IPEndPoint SERVER_ENDPOINT = new IPEndPoint(IPAddress.Parse(SERVER_ADDRESS), DEFAULT_PORT);

        //Socket _serverSocket;

        //public List<Client> _clients;

        //public Server()
        //{
        //    _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        //    _clients = new List<Client>();
        //}

        public void startServer()
        {
            _serverSocket.Bind(SERVER_ENDPOINT);
            _serverSocket.Listen(50);

            //Ponemos al servidor escuchando conexiones en otro HILO diferente al principal para que nos permita 
            //poder seguir usando nuestra aplicacion sin que se detenga completamente.
            new Thread(() =>
            {
                while (true)
                {
                    //Se pone en modo "escucha" hasta que se establezca la conexion.
                    try
                    {
                        Socket client = _serverSocket.Accept();
                        byte[] informacion_que_llega = new byte[1024];
                        client.Receive(informacion_que_llega);

                        String clientName = Encoding.Default.GetString(informacion_que_llega);

                        //Client c = new Client();
                        //c.clientName = clientName;
                        //_clients.Add(c);

                        Console.WriteLine("Se conecto un cliente!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error aceptando conexion: " + ex.ToString());
                    }
                }

            }).Start();
        }
    }
}
