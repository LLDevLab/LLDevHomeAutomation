using System;

namespace IoTCommunicationGui.Exceptions
{
    public class GuiExceptionBase : Exception
    {
        protected GuiExceptionBase(string message)
        : base(message)
        {
        }

        protected GuiExceptionBase(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
