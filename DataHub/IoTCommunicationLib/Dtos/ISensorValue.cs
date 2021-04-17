namespace IoTCommunicationLib.Dtos
{
    public interface ISensorValue
    {
        string Id { get; }
        string Value { get; }
        string ValueUnit { get; }
    }
}
