using IoTCommunicationLib;
using IoTCommunicationLib.IoTSettings;

namespace IoTCommunicationLibTests
{
    class MqttSettings : ICommunicationSettings
    {
        public CommunicationType Type => CommunicationType.Mqtt;

        public string Uri => "127.0.0.1";

        public int Port => 1883;

        public string SubscriptionTopic => "/IoTCommunicationLibTests/publish/test";

        public string ClientId { get; private init; }

        public MqttSettings(string clientId)
        {
            ClientId = clientId;
        }
    }
}
