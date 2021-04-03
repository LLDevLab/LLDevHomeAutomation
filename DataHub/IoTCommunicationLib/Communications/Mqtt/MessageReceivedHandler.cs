using MQTTnet;
using System.Threading.Tasks;

namespace IoTCommunicationLib.Communications.Mqtt
{
    class MessageReceivedHandler : IApplicationMessageReceivedHandler
    {
        public event ApplicationMessageEventHandler ApplicationMessageReceivedHandler;

        public Task HandleApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs eventArgs) => Task.Run(() => 
            ApplicationMessageReceivedHandler?.Invoke(this, new ApplicationMessageEventArgs(System.Text.Encoding.UTF8.GetString(eventArgs.ApplicationMessage.Payload))));

    }
}
