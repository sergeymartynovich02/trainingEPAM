﻿using System;
using System.Threading;

namespace Lab_Delegates_Timer
{
    public delegate void TimerDelegate();
    public delegate void TimeLeftDelegate(int Number);

    interface ICutDownNotifier
    {
        void Init();
        void Run();
    }

    class Timer
    {
        public event TimerDelegate RunTimer = null;
        public event TimeLeftDelegate TimeLeft = null;
        public event TimerDelegate EndTimer = null;

        public string TimerName { get; set; }
        public int NumberOfSeconds { get; set; }

        public Timer(int NumberOfSeconds, string Name)
        {
            this.NumberOfSeconds = NumberOfSeconds;
            TimerName = Name;
        }

        public Timer() { }

        public void TimerRun()
        {
            Console.WriteLine("\nИмя таймера: " + TimerName);
            if (RunTimer != null)
            {
                RunTimer();
            }
        }

        public void OnTimeLeft(int Seconds)
        {
            Console.WriteLine($"Осталось {NumberOfSeconds - Seconds} секунд...");
        }

        public void OnEndCounting()
        {
            Console.WriteLine("Отсчет завершен\n");
        }

        public void StartCounting()
        {
            int Counter = 0;
            for (int i = 1; i <= NumberOfSeconds; i++)
            {
                Thread.Sleep(800);
                if (Counter == NumberOfSeconds / 3)
                {
                    TimeLeft(i);
                    Counter = -1;
                }
                Counter++;
            }
            EndTimer();
        }
    }

    class UserClass : Timer, ICutDownNotifier
    {
        public UserClass(int Number, string Name) : base(Number, Name) { }

        public Timer timer = null;

        public void Init()
        {
            timer = new Timer(NumberOfSeconds, TimerName);
            timer.RunTimer += timer.StartCounting;
            timer.TimeLeft += timer.OnTimeLeft;
            timer.EndTimer += timer.OnEndCounting;
        }

        public void Run()
        {
            if (timer == null)
            {
                Init();
            }
            timer.TimerRun();
        }
    }

    class UserClass_2 : UserClass
    {
        public UserClass_2(int NumberOfSeconds, string Name) : base(NumberOfSeconds, Name) { }

        public new void Init()
        {
            timer = new Timer(NumberOfSeconds, TimerName);
            timer.RunTimer += delegate ()
            {
                int Counter = 0;
                Console.WriteLine(TimerName + ":");
                for (int i = 1; i <= NumberOfSeconds; i++)
                {
                    Thread.Sleep(800);
                    if (Counter == NumberOfSeconds / 3)
                    {
                        timer.OnTimeLeft(i);
                        Counter = -1;
                    }
                    Counter++;
                }
                timer.OnEndCounting();
            };
        }
    }

    class UserClass_3 : UserClass
    {
        public UserClass_3(int Number, string Name) : base(Number, Name) { }

        public new void Init()
        {
            timer = new Timer(NumberOfSeconds, TimerName);
            timer.RunTimer += () =>
            {
                int Counter = 0;
                Console.WriteLine(TimerName + ":");
                for (int i = 1; i <= NumberOfSeconds; i++)
                {
                    Thread.Sleep(800);
                    if (Counter == NumberOfSeconds / 3)
                    {
                        timer.OnTimeLeft(i);
                        Counter = -1;
                    }
                    Counter++;
                }
                timer.OnEndCounting();
            };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] Name = { "Чтение задания", "Выполнение задания", "Проверка задания перед отправкой" };
            int[] Number = new int[3];

            Console.Write("Сколько времени на чтение задания: ");
            Number[0] = Convert.ToInt32(Console.ReadLine());
            Console.Write("Сколько времени на выполнение задания: ");
            Number[1] = Convert.ToInt32(Console.ReadLine());
            Console.Write("Сколько времени на проверку задания перед отправкой: ");
            Number[2] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            ICutDownNotifier[] Elements =
            {
                new UserClass(Number[0], Name[0]),
                new UserClass_2(Number[1], Name[1]),
                new UserClass_3(Number[2], Name[2])
            };

            for (int i = 0; i < Elements.Length; i++)
            {
                Elements[i].Run();
            }
            Console.Write("Отсчёт всех таймеров успешно завершён! \nНажмите любую кнопку для выхода из программы...\n");
            Console.ReadKey();
        }
    }
}