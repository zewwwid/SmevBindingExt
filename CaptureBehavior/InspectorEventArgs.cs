using System;

namespace CaptureBehavior
{
    public class InspectorEventArgs : EventArgs
    {
        public InspectorEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
