using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChatServer
{
    class Client
    {
        TcpClient tcpClient;
        StreamReader reader;
        StreamWriter writer;
        public event Action<Client, string> MsgReceived;
        public int ID { get; set; }

        public Client(TcpClient tcpClient)
        {
            this.tcpClient = tcpClient;

            NetworkStream stream = tcpClient.GetStream();

            writer = new StreamWriter(stream);
            writer.AutoFlush = true;

            StreamReader reader = new StreamReader(stream);
            ReceiveMsg(reader);
        }

        public void SendMsg(string msg)
        {
            writer.Write(msg);
        }

        async void ReceiveMsg(StreamReader reader)
        {
            char[] str = new char[100];
            int x = await reader.ReadAsync(str, 0, 100);
            string msg = new string(str);

            if (MsgReceived != null)
            {
                MsgReceived(this,msg);
            }
        }
    }
}
