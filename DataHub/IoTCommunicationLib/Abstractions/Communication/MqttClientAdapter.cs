using IoTCommunicationLib.Communications.Mqtt;
using MQTTnet.Protocol;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;
using IoTCommunicationLib.Dtos;

namespace IoTCommunicationLib.Abstractions.Communication
{
    class MqttClientAdapter: IClient, IDisposable
    {
        public event SensorMessageEventHandler SensorMessageReceived;

        public event EventHandler ClientConnectedEventHandler
        {
            add => _client.ClientConnected += value;
            remove => _client.ClientConnected -= value;
        }

        readonly MqttClient _client;

        public MqttClientAdapter(MqttClient client)
        {
            _client = client;
            _client.MqttMessageReceived += OnMqttMessageReceived;
        }

        public Task ConnectAsync() => _client.ConnectAsync();

        public Task SubscribeAsync(string topic, QoSType qualityOfServece) => _client.Subscribe(topic, MapToMqttQualityOfServiceLevel(qualityOfServece));

        static MqttQualityOfServiceLevel MapToMqttQualityOfServiceLevel(QoSType qos)
        {
            var ret = qos switch
            {
                QoSType.AtLeastOnce => MqttQualityOfServiceLevel.AtLeastOnce,
                QoSType.AtMostOnce => MqttQualityOfServiceLevel.AtMostOnce,
                QoSType.ExacltyOnce => MqttQualityOfServiceLevel.ExactlyOnce,
                _ => throw new NotImplementedException($"Mapping to {qos} quality of service is not implemented."),
            };
            return ret;
        }

        void OnMqttMessageReceived(object sender, ApplicationMessageEventArgs eventArgs)
        {
            var message = JsonConvert.DeserializeObject(eventArgs.Message, typeof(SensorValueDto));
            SensorMessageReceived?.Invoke(sender, new SensorMessageEventArgs(message as ISensorValue));
        }

        #region IDisposable
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _client.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion IDisposable
    }
}
