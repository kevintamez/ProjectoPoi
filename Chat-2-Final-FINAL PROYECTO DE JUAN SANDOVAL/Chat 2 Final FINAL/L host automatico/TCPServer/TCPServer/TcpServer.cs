using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.IO;

namespace TCPServer
{
    class TcpServer{
        Byte[] receiveByte;
        private TcpListener _server;
        private UdpClient _listener;
        IPEndPoint ipa = new IPEndPoint(IPAddress.Any, 0);
      //  IPEndPoint ipas = new IPEndPoint(IPAddress.Any, 11110);
       
        private Boolean _isRunning;
        private List <TcpClient> listaClientes;
        private String _privateClient = null;

        public TcpServer(int port)
        {
            listaClientes = new List<TcpClient>();
            _server = new TcpListener(IPAddress.Any, 5555);
            _listener = new UdpClient(9050);
            _server.Start();
            _isRunning = true;
            LoopClients();
        }

        public void LoopClients()
        {
            while (_isRunning)
            {
                // wait for client connection
                TcpClient newClient = _server.AcceptTcpClient();
              
                listaClientes.Add(newClient);
                int f = newClient.GetHashCode();
                
                // client found.
                // create a thread to handle communication

                Thread x = new Thread(new ParameterizedThreadStart(HandleClientUDP));
                Thread t = new Thread(new ParameterizedThreadStart(HandleClientTCP));
                t.Start(newClient);
                x.Start(newClient);
            }
        }
        public void HandleClientUDP(object obj){
            TcpClient client = (TcpClient)obj;
            Boolean connection = true;
          
            while(connection == true)
            {
                receiveByte = _listener.Receive(ref ipa);

                foreach (TcpClient x in listaClientes)
                {
                    if (x.Connected ==true)
                    {    
             _listener.Send(receiveByte,receiveByte.Length,ipa);
                    }
                }

            }
        
        }

        public void HandleClientTCP(object obj)
          
        {
            // retrieve client from parameter passed to thread
            TcpClient client = (TcpClient)obj;
          
            // sets two streams
            StreamReader sReader = new StreamReader(client.GetStream(), Encoding.ASCII);
            // you could use the NetworkStream to read and write, 
            // but there is no forcing flush, even when requested
            Boolean bClientConnected = true;
            String sData = null;
            while (bClientConnected)
            {
                try
                {
                    // reads from stream
                    sData = sReader.ReadLine();
                   
                    //here well check if a message needs to be routed to a single recipient
           if(sData[0].Equals('~')){
          
              foreach (TcpClient x in listaClientes)
              {
                  if (x.Connected)
                  {
                      StreamWriter sWriter = new StreamWriter(x.GetStream(), Encoding.ASCII);
                      sWriter.WriteLine(sData);
                      sWriter.Flush();
                  }
                 
              }

           }
           else
           {  
                    foreach(TcpClient x in listaClientes){
                     
                        if (x.Connected) {
                            Console.WriteLine(sData);
                    StreamWriter sWriter = new StreamWriter(x.GetStream(), Encoding.ASCII);
                    sWriter.WriteLine(sData);
                    sWriter.Flush();
                   
                        }
                    }
           }
                }
                catch(Exception){
                    client.Close();
                }
            }
        }
    }
}