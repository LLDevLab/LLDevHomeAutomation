using MQTTnet.Client.Receiving;

namespace IoTCommunicationLib.Communications.Mqtt
{
    interface IApplicationMessageReceivedHandler: IMqttApplicationMessageReceivedHandler
    {
        event ApplicationMessageEventHandler ApplicationMessageReceivedHandler;
    }
}
