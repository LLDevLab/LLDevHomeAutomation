using MQTTnet.Client.Connecting;
using System;

namespace IoTCommunicationLib.Communications.Mqtt
{
    interface IClientConnectedHandler: IMqttClientConnectedHandler
    {
        event EventHandler ClientConnectedEventHandler;
    }
}
