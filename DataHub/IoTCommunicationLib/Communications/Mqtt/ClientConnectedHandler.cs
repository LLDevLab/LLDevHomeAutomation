using MQTTnet.Client.Connecting;
using System;
using System.Threading.Tasks;

namespace IoTCommunicationLib.Communications.Mqtt
{
    class ClientConnectedHandler : IClientConnectedHandler
    {
        public event EventHandler ClientConnectedEventHandler;

        public Task HandleConnectedAsync(MqttClientConnectedEventArgs eventArgs) => Task.Run(() => ClientConnectedEventHandler?.Invoke(this, EventArgs.Empty));
    }
}
