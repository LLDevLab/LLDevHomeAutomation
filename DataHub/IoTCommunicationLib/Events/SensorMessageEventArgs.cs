using IoTCommunicationLib.Dtos;
using System;

namespace IoTCommunicationLib
{
    public sealed class SensorMessageEventArgs : EventArgs
    {
        public ISensorValue SensorValue { get; private set; }

        public SensorMessageEventArgs(ISensorValue sensorValue)
        {
            SensorValue = sensorValue;
        }
    }
}
