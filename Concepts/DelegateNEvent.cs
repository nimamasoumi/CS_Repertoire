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
    }
}
