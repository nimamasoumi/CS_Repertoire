using System;

namespace CS_Repertoire.Concepts
{
    // Creating a custom event argument that does not inherit EventArgs
    internal class CustomEventArgs
    {
        public int eventid { get; set; } = 0;
        public string eventdata { get; set; } = "";

        public CustomEventArgs() { }

        public CustomEventArgs(int _eventid, string _eventdata)
        {
            this.eventid = _eventid;
            this.eventdata = _eventdata;
        }
    }
}
