using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class Form1 : Form
    {
        StreamWriter writer;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            TcpClient client = new TcpClient("192.168.88.86", 5000);
            NetworkStream stream = client.GetStream();

            writer = new StreamWriter(stream);
            writer.AutoFlush = true;

            StreamReader reader = new StreamReader(stream);
            ReceiveMsg(reader);
        }

        async void ReceiveMsg(StreamReader reader)
        {
            char[] str = new char[100];
            int x = await reader.ReadAsync(str, 0, 100);

            txtMsg.Text = new string(str);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            writer.Write(txtMsg.Text);
        }
    }
}
