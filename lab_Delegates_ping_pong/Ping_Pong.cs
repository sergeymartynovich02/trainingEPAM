using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_Delegates_ping_pong
{
    public delegate void Delegate();

    partial class Ping
    {
        public event Delegate ping = null;

        public static void PrintPing()
        {
            Console.WriteLine("Ping received Pong");
        }

        public void OnPing()
        {
            ping = Pong.PrintPong;
            ping();
        }
    }

    partial class Pong
    {
        public event Delegate pong = null;

        public static void PrintPong()
        {
            Console.WriteLine("Pong received Ping");
        }

        public void OnPong()
        {
            pong = Ping.PrintPing;
            pong();
        }

    }
}