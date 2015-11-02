using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Servidor del chat TCP");
            TcpServer server = new TcpServer(5555);
        }
    }
}
