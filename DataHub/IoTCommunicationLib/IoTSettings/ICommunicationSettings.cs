namespace IoTCommunicationLib.IoTSettings
{
    public interface ICommunicationSettings
    {
        CommunicationType Type { get; }
        string Uri { get; }
        int Port { get; }
        string SubscriptionTopic { get; }
    }
}
