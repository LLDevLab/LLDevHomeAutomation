using System;

namespace IoTCommunicationLib
{
    sealed class ApplicationMessageEventArgs: EventArgs
    {
        public string Message { get; private set; }

        public ApplicationMessageEventArgs(string message)
        {
            Message = message;
        }
    }
}
