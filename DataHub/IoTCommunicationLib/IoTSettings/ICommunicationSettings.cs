namespace IoTCommunicationLib.IoTSettings
{
    public interface ICommunicationSettings
    {
        string ClientId { get; }
        CommunicationType Type { get; }
        string Uri { get; }
        int Port { get; }
        string SubscriptionTopic { get; }
    }
}
