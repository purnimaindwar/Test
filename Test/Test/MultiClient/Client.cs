using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using log4net.Config;
using log4net;

namespace MultiClient
{
    class Client
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static Socket sck;
        static string name = "";
        static string msg = "";
        public static void Send()
        {
            while (true)
            {
                msg = Console.ReadLine();
                try
                {

                    byte[] data = Encoding.Default.GetBytes(name + "#" + msg);
                    sck.Send(data, 0, data.Length, 0);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        public static void Read()
        {
            while (true)
            {
                if (msg.Equals("logout"))
                    return;
                try
                {
                    byte[] Buffer = new byte[255];
                    int rec = sck.Receive(Buffer, 0, Buffer.Length, 0);
                    Array.Resize(ref Buffer, rec);
                    string dis = Encoding.Default.GetString(Buffer);
                    Console.WriteLine(dis);
                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                }
            }
        }
        /// <summary>
        /// Connection 
        /// </summary>
        static void Connection()
        {
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Console.Write("Enter Name : ");
            name = Console.ReadLine();
            Console.WriteLine("Connecting.....");

            IPEndPoint ed = new IPEndPoint(IPAddress.Parse("192.168.1.10"), 6893);
            try
            {
                sck.Connect(ed);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            byte[] send = Encoding.Default.GetBytes(name);
            sck.Send(send, 0, send.Length, 0);
            byte[] Buf = new byte[255];
            int rec = sck.Receive(Buf, 0, Buf.Length, 0);
            Array.Resize(ref Buf, rec);
            string dis = Encoding.Default.GetString(Buf);
            Console.WriteLine(dis + " Connected.....");
            Console.Write("Enter Name to connect Another Client :");
            string conn = Console.ReadLine();
            send = Encoding.Default.GetBytes(conn);
            sck.Send(send, 0, send.Length, 0);
        }
        static void Main(string[] args)
        {
            try
            {
                Connection();
                Thread thread1 = new Thread(new ThreadStart(Send));
                Thread thread2 = new Thread(new ThreadStart(Read));

                thread1.Start();
                thread2.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

