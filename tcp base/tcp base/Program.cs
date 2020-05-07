using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace ClientSocket
{
    class Program
    {
        static Socket skc;
        static void Main(string[] args)
        {
            skc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
            try
            {
                skc.Connect(localEndPoint);

                Console.Write("\n Inserisci il testo:");
                string text = Console.ReadLine();
                byte[] data = Encoding.ASCII.GetBytes(text);
                skc.Send(data);
                Console.Write("\n Messaggio inviato correttamente");
                Console.Write("\n Premi un tasto per continuare...");
                Console.Read();
                skc.Close();
            }
            catch (Exception ex)
            {
                Console.Write("\n Connessione fallita:" + " " + ex.Message);
                Main(args);
            }

        }
    }
}