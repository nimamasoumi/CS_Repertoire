using System;

namespace CS_Repertoire
{
    internal class StaticTest
    {
        public static int NofInst = 0;
        public StaticTest() { NofInst++; }
        //~StaticTest() { }        

        public static int A = 13;

        public int B = 0;

        public void SumOfAB() { Console.WriteLine("The sum is: {0}", A + B); }
    }
}
