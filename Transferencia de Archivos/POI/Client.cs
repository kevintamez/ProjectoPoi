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

//Para enviar imagenes
using System.IO;

namespace POI
{
    public class Client
    {
        private Socket _clientSocket;
        private Server _server;

        public Client()
        {
            _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void connect()
        {
            new Thread(() =>
            {
               try
               {
                   _clientSocket.Connect(_server.SERVER_ENDPOINT);
               }
               catch (Exception ex)
               {
                   Console.WriteLine("Error conectando al cliente.");
               }
            }).Start();
        }

        public void sendImage(byte[] imageBytes)
        {
            _clientSocket.Send(imageBytes);
        }

        //Socket _clientSocket;

        //public String clientName;

        //public Client()
        //{
        //    _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //}

        //public Client(Socket clientSocket)
        //{
        //    _clientSocket = clientSocket;
        //}

        //public void Connect(String name)
        //{
        //    //Establece la conexion con el servidor ya que la variable endpoint
        //    //que estamos usando incluye la IP y el puerto por el cual el servidor
        //    //esta escuchando o recibiendo conexiones.
        //    try
        //    {
        //        _clientSocket.Connect(Server.SERVER_ENDPOINT);

        //        //La cadena de string la convertimos en un arreglo de bytes para enviarla
        //        _clientSocket.Send(Encoding.Default.GetBytes(name));
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error conectando al cliente: " + ex.ToString());
        //    }
        //}
    }
}
