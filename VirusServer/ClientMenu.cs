using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace VirusServer
{
    public partial class ClientMenu : Form
    {
        public Socket socket;

        public ClientMenu()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            Button buttonPressed = sender as Button;
            SendMenu sendMenu = new SendMenu();
            sendMenu.Action = buttonPressed.Text;
            sendMenu.socket = socket;
            sendMenu.Show();
        }
    }
}
