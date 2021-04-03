using DbCommunicationLib.Controller.SensorEvents;
using System;

namespace DbCommunicationLib.Model
{
    public partial class SensorEvent
    {
        public ISensorEventController GetController()
        {
            SensorEventControllerBase result = (SensorEventTypes)EventType switch
            {
                SensorEventTypes.On or SensorEventTypes.Off => new OnOffSensorEventController(this),
                _ => throw new NotImplementedException($"Controller for event type {EventType} is not implemented."),
            };
            return result;
        }
    }
}
