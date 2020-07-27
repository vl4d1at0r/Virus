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
    public partial class SendMenu : Form
    {
        public string Action;
        public bool moreThanOneParameter;
        public Socket socket;
        public SendMenu()
        {
            InitializeComponent();
        }

        private void SendMenu_Load(object sender, EventArgs e)
        {
            switch (Action)
            {
                case "Create":
                    firstParameterLabel.Text = "Path";
                    moreThanOneParameter = false;
                    break;
                case "Delete":
                    firstParameterLabel.Text = "Path";
                    moreThanOneParameter = false;
                    break;
                case "Rename":
                    firstParameterLabel.Text = "Path";
                    secondParameterLabel.Text = "Name";
                    moreThanOneParameter = true;
                    break;
            }

            if (!moreThanOneParameter)
            {
                secondParameterLabel.Hide();
                secondParameter.Hide();
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            string command = Action.ToLower();
            string request = command + "|" + firstParameter.Text + "|" + secondParameter.Text;
            byte[] buffer = Encoding.UTF8.GetBytes(request);
            socket.Send(buffer);
        }
    }
}
