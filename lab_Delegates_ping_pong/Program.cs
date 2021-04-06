using System;
using System.Threading;

namespace lab_Delegates_ping_pong
{
    class Program
    {
        static void StartGame(Ping A, Pong B)
        {
            Random rand = new Random();
            int HitCounter = 1;
            int HitNumber = rand.Next(2, 10);
            for (int i = 0; i < HitNumber; i++)
            {
                Console.Write(HitCounter + ". ");
                A.OnPing();
                HitCounter++;
                Thread.Sleep(500);
                Console.Write(HitCounter + ". ");
                B.OnPong();
                HitCounter++;
                Thread.Sleep(500);
            }
        }

        static void Main(string[] args)
        {
            Ping A = new Ping();
            Pong B = new Pong();
            StartGame(A, B);
        }
    }
}
