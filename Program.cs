﻿using System;
using System.Threading;

namespace CS_Repertoire
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread cdown1 = new(() => CountDown(1, 19));
            cdown1.Name = "DownCounter1";

            Thread cdown2 = new Thread(() => CountDown(2, 13))
            { Name = "DownCounter2" };
            Thread cup1 = new(() => CountUp(1, 7))
            { Name = "UpCounter1" };

            cdown1.Start();
            cdown2.Start();
            cup1.Start();

            // Exploring the incredible static modifier in C#
            Console.WriteLine("Let's test the static modifier!");

            StaticTest inst1 = new StaticTest();
            inst1.B = 19;
            inst1.SumOfAB();

            StaticTest inst2 = new StaticTest();
            inst2.B = 39;
            inst2.SumOfAB();

            Console.WriteLine("Number of StaticTest instances: {0}", StaticTest.NofInst);
            StaticTest.A = 63;

            Console.WriteLine("\nChanging parameter A");
            inst1.SumOfAB();
            inst2.SumOfAB();

            Console.WriteLine("Counter {0} finished.", cdown1.Name);
            Console.WriteLine("Counter {0} finished.", cdown2.Name);
            Console.WriteLine("Counter {0} finished.", cup1.Name);

            Console.ReadKey();


        }
        public static void CountDown(int cnum, int num)
        {
            Console.WriteLine("The down counter #{0} started!", cnum);
            int N = num;
            for (int i = N;i>0;i--)
            {
                Console.WriteLine("The down counter #{0} is: {1}", cnum,i);
                Thread.Sleep(100);
            }
            
        }
        public static void CountUp(int cnum, int num)
        {
            Console.WriteLine("The up counter #{0} started!", cnum);
            int N = num;
            for (int i = 1; i <= N; i++)
            {
                Console.WriteLine("The up counter #{0} is: {1}", cnum, i);
                Thread.Sleep(100);
            }

        }

    }
}
