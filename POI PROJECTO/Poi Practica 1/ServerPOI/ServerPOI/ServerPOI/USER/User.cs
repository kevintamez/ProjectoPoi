using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.IO;
namespace ServerPOI.USER
{
    public class User
    {
        public String userName;
        public UserState userState;
        public IPEndPoint userEP;
        public Socket userSocket;
        public bool serverOn;
        public bool userIsAlive;
        int userNo;
        frmSever Server;

        public void startClient(Socket inClientSocket, int clineNo, frmSever Serv)
        {
            Server = Serv;
            serverOn = true;
            userSocket = inClientSocket;
            this.userNo = clineNo;
            Thread ctThread = new Thread(WaitingMessage);
            ctThread.Start();
            userIsAlive = true;
        }

        private void WaitingMessage()
        {

            int recv;
            byte[] data = new byte[1024];
            //Inf que recibe
            data = new byte[1024];
            recv = this.userSocket.Receive(data);
            string userD = Encoding.ASCII.GetString(data, 0, recv);
            string[] userData = Regex.Split(userD, "\r\n");
            this.userName = userData[0];
            switch (userData[1]) { 
                case "Connected":
                    this.userState = UserState.Connected;
                    break;
                case "Absent":
                    this.userState = UserState.Absent;
                    break;
                case "Busy":
                    this.userState = UserState.Busy;
                    break;
            }

            string welcome = "Bienvenido " + this.userName + " al servidor, su estado es " + this.userState.ToString() + "\n";
            //Convertir bienvenida a bytes
            data = Encoding.ASCII.GetBytes(welcome);
            //Enviar al cliente la informacion, Informacion y tamaño
            this.userSocket.Send(data, data.Length, SocketFlags.None);

            while (serverOn)
            {
                
                recv = this.userSocket.Receive(data);
                if (recv == 0)
                    break;
                //Imprimir lo que reciba
                Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));

                if (Encoding.ASCII.GetString(data, 0, recv) == "exit")
                    break;

                //Respuesta de que llego
                /*
                this.userSocket.Send(data, recv, SocketFlags.None);
                if (userNo == 0)
                {
                    if (Server.Client[1].userSocket != null)
                    {
                        Server.Client[1].userSocket.Send(data, recv, SocketFlags.None);
                    }
                }
                else {
                    Server.Client[0].userSocket.Send(data, recv, SocketFlags.None);
                }*/

                for (int i = 0; i < Server.countClient; i++) {
                    try
                    {
                        if (Server.Client[i].userIsAlive) { 
                            if ((Encoding.ASCII.GetString(data, 0, recv) == "&!buzz$%!") && !(Server.Client[i].userSocket != this.userSocket))
                                Server.Client[i].userSocket.Send(data, recv, SocketFlags.None);
                            else if(!(Encoding.ASCII.GetString(data, 0, recv) == "&!buzz$%!"))
                                Server.Client[i].userSocket.Send(data, recv, SocketFlags.None);
                        }
                    }
                    catch (SocketException e) {
                        e.ToString();
                    }
                }

            }
            Console.WriteLine("Desconectado de " + this.userEP.Address);
            
            this.userSocket.Close();
            userIsAlive = false;
        }


    }
}
