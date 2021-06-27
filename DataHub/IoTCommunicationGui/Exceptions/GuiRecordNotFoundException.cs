using System;

namespace IoTCommunicationGui.Exceptions
{
    public class GuiRecordNotFoundException : GuiExceptionBase
    {
        public GuiRecordNotFoundException(string message)
        : base(message)
        {
        }

        public GuiRecordNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
