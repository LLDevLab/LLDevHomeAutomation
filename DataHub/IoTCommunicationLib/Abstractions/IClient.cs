using System;
using System.Threading.Tasks;

namespace IoTCommunicationLib.Abstractions
{
    public interface IClient
    {
        event EventHandler ClientConnectedEventHandler;
        event SensorMessageEventHandler SensorMessageReceived;
        Task ConnectAsync();
        Task SubscribeAsync(string topic, QoSType qualityOfServece);
    }
}
