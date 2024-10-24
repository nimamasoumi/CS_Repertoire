using System;
using System.Threading;
using System.Configuration;
using System.Collections.Specialized;
using CS_Repertoire.Concepts;
using System.Runtime.CompilerServices;

namespace CS_Repertoire
{
    class Program
    {
        public static void calcAreaCircumference(out double area, out double circumference, double r)
        {
            area = Math.PI * Math.Pow(r, 2.0);
            circumference = 2 * Math.PI * r;
        }
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

            // testing partial classes
            var mycalc = new calc();
            int x = 3, y = 4;
            Console.WriteLine("Addition: {0}\nSubtraction: {1}\nMultiplication: {2}\nDivision: {3}"
                , mycalc.add(x, y),mycalc.sub(x,y), mycalc.mul(x, y), mycalc.div(x, y));

            #region testing App.config file key/value pairs

            // reading a particular key from configuration
            string sAttr = ConfigurationManager.AppSettings.Get("key19");
            Console.WriteLine("value for key19 is: "+ sAttr);

            // reading all the key/value pairs at the same time
            NameValueCollection sAll = ConfigurationManager.AppSettings;
            foreach(string s in sAll.AllKeys)
            {
                Console.WriteLine("The value for " + s + " is " + sAll.Get(s));
            }

            #endregion

            #region testing out keyword
            double radius = 19.0;

            // notice below that area and circumference variables were not declared beforehand
            // also the function below does not have a return value and work with references
            calcAreaCircumference(out double area, out double circumference, radius);
            Console.WriteLine("Circle with radius {0}: area={1}, circumference={2}", radius, area, circumference);
            #endregion

            #region testing the event keyword
            EventPublisherTest e1 = new EventPublisherTest();

            // Line below is raising a notification
            // Similar to clicking a button etc
            e1.tryToInvokeEvent1();

            // raising the event with some data
            V1EventArgs e1arg = new V1EventArgs(2, "This is the second call of the event");
            e1.tryToInvokeEvent1(e1arg);


            // raising event 2
            e1.tryToInvokeEvent2();

            // unsubscribing the event 2 executable
            bool success2 = e1.unsubscribeEvent2Exec();
            Console.WriteLine("Event 2 was unsubscribed: "+success2);
            #endregion

            #region comparing events and delegates
            var e2 = new DelegateNEvent();
            e2.event3 += EventGreeting;
            e2.event4 += EventGreeting;

            // This is a count-down to raise the events;
            for (int ii=19;ii>0; ii--)
            {                
                Thread.Sleep(100);

                e2.CountChecker(ii);
            }

            // the delegate can be raised here!
            e2.event4?.Invoke(e2, new CustomEventArgs(4, "Hello dear user!"));
            // however the event can not be invoked and generates an error
            //e2.event3?.Invoke(e2, new CustomEventArgs(3, "Hello dear user!"));
            #endregion

            #region examples of lambda expression and its connection with delegates
            e2.RunLambdaExamples();
            #endregion

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
        
        public static void EventGreeting(object? sender, CustomEventArgs e)
        {
            Console.WriteLine("Greeting to the dear user! EventID: {0}, EventData: {1}", e.eventid, e.eventdata);
        }
    }
}
