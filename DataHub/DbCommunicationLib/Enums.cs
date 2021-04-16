namespace DbCommunicationLib
{
    /// <summary>
    /// Bit masked type
    /// </summary>
    public enum SensorType
    {
        Undefined = 0,
        OnOffSensor = 1,
        Temperature = 2,
        Pressure = 4
    }

    /// <summary>
    /// Type of event
    /// </summary>
    public enum SensorEventTypes
    {
        Measurement = 0,
        On = 1,
        Off = 2
    }
}
