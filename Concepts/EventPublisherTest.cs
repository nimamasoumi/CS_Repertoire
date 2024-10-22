using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Repertoire.Concepts
{
    internal class EventPublisherTest
    {
        /*
         * There are three main steps when using the events
         * 1. Create the event
         * 2. Subscribe to the event
         * 3. Raise the event
        */

        // Create the event
        public event EventHandler<V1EventArgs> event1;
        public event EventHandler event2;
        public EventPublisherTest() 
        {
            // += operator is used to subscribe to events
            this.event1 += new EventHandler<V1EventArgs>(this.event1executable);

            this.event2 += new EventHandler(this.event2executable);
        }

        // This function is executed when the event is raised
        private void event1executable(object sender, V1EventArgs e)
        {
            Console.WriteLine("Testing the invocation of the event1.");

            if (e != null)
            {
                Console.WriteLine("The event ID is: " + e.eventid);
                Console.WriteLine("The event data is: "+e.eventdata);
            }
        }

        // testing Empty field in EventArgs
        private void event2executable(object sender, EventArgs e)
        {
            Console.WriteLine("Testing the Empty field in EventArgs.");          
        }

        // Below function is used by the external users to invoke the event
        public void tryToInvokeEvent1()
        {   
            V1EventArgs _e = null;
            this.event1?.Invoke(this, _e);
        }        

        public void tryToInvokeEvent1(V1EventArgs _e)
        {
            this.event1?.Invoke(this, _e);
        }

        public void tryToInvokeEvent2()
        {
            // we use Empty field instead of null            
            this.event2?.Invoke(this, EventArgs.Empty);
        }

        // Unsubscribing event 2
        public bool unsubscribeEvent2Exec()
        {
            this.event2 -= new EventHandler(this.event2executable);
            return true;
        }
    }

    // Creating a custom event data
    internal class V1EventArgs : EventArgs
    {
        public int eventid { get; set; }
        public string eventdata { get; set; }

        public V1EventArgs() { }
        public V1EventArgs(int _eventid, string _eventdata)
        {
            this.eventid = _eventid;
            this.eventdata = _eventdata;
        }
        
         
    }
}
