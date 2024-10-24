using System;

namespace CS_Repertoire.Concepts
{
    /* 
     * this class is implementing delegate concepts
     * also it compares the event with delegate
     * 
    */
    internal class DelegateNEvent
    {
        public delegate void CustomHandler(object? sender, CustomEventArgs e);
        public event CustomHandler event3;

        // this delegate does not have event modifier but it is going to work the same
        // however, there will be encapsulation issues
        public CustomHandler event4; 

        // Wrap the event in a protected virtual method
        // to enable derived classes to raise the event.
        protected virtual void raiseEvents(int _eventid)
        {
            // Raise the event in a thread-safe manner using the ?. operator.
            switch (_eventid)
            {
                case 3:
                    event3?.Invoke(this, new CustomEventArgs(_eventid, "Hello dear user!"));
                    break;
                case 4:
                    event4?.Invoke(this, new CustomEventArgs(_eventid, "Hello dear user!"));
                    break;
                default:
                    Console.WriteLine("The specified ID {0} does not associate with available events", _eventid);
                    break;
            }            
        }

        public void CountChecker(int _ii)
        {
            if(_ii == 7)
            {
                raiseEvents(3);
            }
            if (_ii == 13)
            {
                raiseEvents(4);
            }
        }

        // providing lambda expression examples and its connection to delegate types
        public void RunLambdaExamples()
        {
            Console.WriteLine("\n\nPerforming some lambda examples\n");
            // Func delegate assigned to lambda expression
            Func<int, int> square = x => x * x;
            Console.WriteLine(square(7));

            // Action delegate assigned to lambda expression
            Action<string> greet = name =>
            {
                string greeting = $"Hello {name}!";
                Console.WriteLine(greeting);
            };
            greet("dear lambda expression learner");

            // lambda with no input
            Action line = () => Console.WriteLine("Empty lambda expression.");
            line();

            // lambda with several inputs
            Func<int, int, bool> test = (x, y) => x == y;
            Console.WriteLine(test(13, 19));

            // lambda with emplicit input types
            Func<int, string, bool> isTooLong = (int x, string s) => s.Length > x;
            Console.WriteLine(isTooLong(24, "learning curve of lambda expressions is steep"));

            // lambda with discarded inputs
            Func<int, int, double> PIconstant = (_, _) => 3.141;
            Console.WriteLine(PIconstant(1,2));

            // default value for input and cleaner way to define lambda 
            // this is available in version 12.0 or greater
            //var incrementBy = (int source, int increment = 1) => source + increment;
            //Console.WriteLine(incrementBy(7));
            //Console.WriteLine(incrementBy(13, 19));
        }
    }
}
