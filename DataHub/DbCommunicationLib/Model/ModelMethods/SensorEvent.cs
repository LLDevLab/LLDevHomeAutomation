using DbCommunicationLib.Controller.SensorEvents;
using System;

namespace DbCommunicationLib.Model
{
    public partial class SensorEvent
    {
        public ISensorEventController GetController()
        {
            if (UnitId == null)
                return new OnOffSensorEventController(this);

            var measurementUnits = (MeasurementUnits)UnitId;

            SensorEventControllerBase result = measurementUnits switch
            {
                MeasurementUnits.DegreeCelsius => new TemperatureSensorEventController(this),
                MeasurementUnits.Pascals => new PressureSensorEventController(this),
                _ => throw new NotImplementedException($"Event type {measurementUnits} not implemented.")
            };
            return result;
        }
    }
}
