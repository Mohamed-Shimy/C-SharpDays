using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatServer
{
    public partial class Form1 : Form
    {
        TcpListener listener;
        StreamWriter writer;
        SynchronizationContext context;
        Dictionary<int, Client> clients;

        public Form1()
        {
            InitializeComponent();

            //IPAddress ip = new IPAddress(new byte[] { 192, 168, 88, 86 });
            IPAddress ip = IPAddress.Parse("192.168.88.86");
            listener = new TcpListener(ip, 5000);
            context = SynchronizationContext.Current;
        }

        public void AcceptConnections()
        {
            while (true)
            {
                Client client = new Client(listener.AcceptTcpClient());

                client.MsgReceived += Client_MsgReceived;

                clients.Add(client.ID, client);
            }
        }

        private void Client_MsgReceived(Client client, string msg)
        {
            txtMsg.Text += msg;
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            listener.Start();

            Task.Run(() => AcceptConnections());
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //client.SendMsg(txtMsg.Text);
        }
    }
}
