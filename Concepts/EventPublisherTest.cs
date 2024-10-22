using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Repertoire.Concepts
{
    internal class EventPublisherTest
    {

        public event EventHandler event1;
        public EventPublisherTest() 
        {
            this.event1 += new System.EventHandler(this.event1executable);
        }

        // This function is executed when the event is raised
        private void event1executable(object sender, EventArgs e)
        {
            Console.WriteLine("Testing the invokation of the event1.");
        }

        // Below function is used by the external users to invoke the event
        public void tryToInvokeEvent1()
        {
            this.event1?.Invoke(this, EventArgs.Empty);
        }

    }
}
