using System;

namespace CS_Repertoire.Concepts
{
    internal class ManagingMultipleEvents
    {
        // creating a delegate to hold multiple event handlers
        public event EventHandler? MulEventManager; 

        // other objects will use below function to signal raising the event
        public void MonitorMulEvent(int _raisecontrol)
        {
            if (_raisecontrol==19)
            {
                RaiseMulEvent();
            }
        }

        // function below is used to raise the eent
        protected virtual void RaiseMulEvent()
        {
            this.MulEventManager?.Invoke(this, EventArgs.Empty);
        }

        // function below counts the number of event handlers
        public int CountEventHandlers()
        {
            int num = 0;
            if (this.MulEventManager != null)
            {
                num = this.MulEventManager.GetInvocationList().Length;
            }
             
            return num;
        }

        // function below will remove all the event handlers from the event
        public void ClearMulEvent()
        {
            this.MulEventManager = null;
        }

        public void AddEventHandlers()
        {
            this.MulEventManager += new EventHandler(this.ex1);
            this.MulEventManager += new EventHandler(this.ex2);
            this.MulEventManager += new EventHandler(this.ex3);
            this.MulEventManager += new EventHandler(this.ex4);
            this.MulEventManager += new EventHandler(this.ex5);
            this.MulEventManager += new EventHandler(this.ex6);
            this.MulEventManager += new EventHandler(this.ex7);
        }

        #region creating example event handlers
        private void ex1(object? sender, EventArgs e) { }
        private void ex2(object? sender, EventArgs e) { }
        private void ex3(object? sender, EventArgs e) { }
        private void ex4(object? sender, EventArgs e) { }
        private void ex5(object? sender, EventArgs e) { }
        private void ex6(object? sender, EventArgs e) { }
        private void ex7(object? sender, EventArgs e) { }
        #endregion
    }
}
