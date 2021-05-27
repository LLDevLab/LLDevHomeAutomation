namespace DbCommunicationLib
{
    public enum SensorTypeEnum
    {
        OnOffSensor = 0,
        Temperature = 1,
        Pressure = 2,
        Humidity = 3
    }

    public enum OnOffEventValue
    {
        On = 0,
        Off = 1
    }

    public enum MeasurementUnits
    {
        DegreeCelsius = 1,
        Pascals = 2
    }
}
