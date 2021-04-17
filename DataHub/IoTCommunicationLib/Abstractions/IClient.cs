using System;
using System.Threading.Tasks;

namespace IoTCommunicationLib.Abstractions
{
    public interface IClient
    {
        event EventHandler ClientConnectedEventHandler;
        event SensorMessageEventHandler SensorMessageReceived;
        Task ConnectAsync();
        Task DisconnectAsync();
        Task SubscribeAsync(string topic, QoSType qualityOfServece);
        Task PublishAsync(string topic, string message);
    }
}
