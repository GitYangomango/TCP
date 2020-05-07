using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace serversocket
{
    class Program
    {
        static byte[] Buffer { get; set; }
        static Socket sck;
        static void Main(string[] args)
        {
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sck.Bind(new IPEndPoint(0, 1234));
            sck.Listen(100);
            Socket accepted = sck.Accept();
            Buffer = new byte[accepted.SendBufferSize];
            int bytesRead = accepted.Receive(Buffer);
            byte[] formatted = new byte[bytesRead];
            for (int i = 0; i < bytesRead; i++)
            {
                formatted[i] = Buffer[i];
            }
            Console.Write("\t Server" + "\n");
            String stradata = Encoding.ASCII.GetString(formatted);
            Console.Write("-->" + " " + stradata + "\n\n");
            Console.Read();
            sck.Close();
            accepted.Close();

        }
    }
}




