using MQTTnet;
using MQTTnet.Client.Options;
using MQTTnet.Extensions.ManagedClient;
using NLog;
using System;
using MQTTnet.Protocol;
using System.Threading.Tasks;
using IoTCommunicationLib.IoTSettings;

namespace IoTCommunicationLib.Communications.Mqtt
{
    class MqttClient: IDisposable
    {
        public event EventHandler ClientConnected
        {
            add => _clientConnectedEventHandler.ClientConnectedEventHandler += value;
            remove => _clientConnectedEventHandler.ClientConnectedEventHandler -= value;
        }

        public event ApplicationMessageEventHandler MqttMessageReceived
        {
            add => _messageReceivedHandler.ApplicationMessageReceivedHandler += value;
            remove => _messageReceivedHandler.ApplicationMessageReceivedHandler -= value;
        }

        readonly Logger _logger;

        IManagedMqttClient _client;
        ClientConnectedHandler _clientConnectedEventHandler;
        MessageReceivedHandler _messageReceivedHandler;

        public bool IsConnected => _client.IsConnected;

        readonly ICommunicationSettings _settings;

        public MqttClient(ICommunicationSettings settings)
        {
            _settings = settings;

            _logger = LogManager.GetCurrentClassLogger();

            InitMqttClient();
        }

        void InitMqttClient()
        {
            _client = new MqttFactory().CreateManagedMqttClient();

            _clientConnectedEventHandler = new ClientConnectedHandler();
            _clientConnectedEventHandler.ClientConnectedEventHandler += OnClientConnected;
            _client.ConnectedHandler = _clientConnectedEventHandler;

            _messageReceivedHandler = new MessageReceivedHandler();
            _messageReceivedHandler.ApplicationMessageReceivedHandler += OnApplicationMessageReceived;
            _client.ApplicationMessageReceivedHandler = _messageReceivedHandler;
        }

        IManagedMqttClientOptions GetClientOptions()
        {
            var options = new MqttClientOptionsBuilder()
                .WithClientId(_settings.ClientId)
                .WithTcpServer(_settings.Uri, _settings.Port)
                .WithCleanSession();

            var managedClientOptions = new ManagedMqttClientOptionsBuilder()
                .WithAutoReconnectDelay(TimeSpan.FromSeconds(5))
                .WithClientOptions(options.Build())
                .Build();

            return managedClientOptions;
        }

        public Task ConnectAsync() => _client.StartAsync(GetClientOptions());
        public Task DisconnectAsync() => _client.StopAsync();

        public Task SubscribeAsync(string topic, MqttQualityOfServiceLevel qos) => _client.SubscribeAsync(topic, qos);
        public Task PublishAsync(string topic, string message) => _client.PublishAsync(topic, message);

        void OnClientConnected(object sender, EventArgs args)
        {
            _logger.Info($"Client connected to {_settings.Uri}, at port {_settings.Port}");
        }

        void OnApplicationMessageReceived(object sender, ApplicationMessageEventArgs eventArgs)
        {
            _logger.Info($"Message received: {eventArgs.Message}");
        }

        #region IDisposable
        bool disposedValue;

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
