using IoTCommunicationLib;
using IoTCommunicationLib.IoTSettings;

namespace IoTWorkerService
{
    class MqttSettings : ICommunicationSettings
    {
        public CommunicationType Type => CommunicationType.Mqtt;

        public string Uri { get; init; }

        public int Port { get; init; }

        public string SubscriptionTopic { get; init; }

        public string ClientId { get; init; }
    }
}
