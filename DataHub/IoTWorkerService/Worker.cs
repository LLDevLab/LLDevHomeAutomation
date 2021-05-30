using DbCommunicationLib;
using DbCommunicationLib.Controller.Sensors;
using IoTCommunicationLib;
using IoTCommunicationLib.Abstractions;
using IoTCommunicationLib.IoTSettings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IoTWorkerService
{
    public class Worker: BackgroundService
    {
        readonly ILogger<Worker> _logger;
        readonly IoTCommunication _IoTCommunication;

        IClient IoTClient => _IoTCommunication.Client;
        readonly ICommunicationSettings _mqttSettings;
        readonly IServiceScopeFactory _scopeFactory;

        public Worker(ILogger<Worker> logger, ICommunicationSettings mqttSettings, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _mqttSettings = mqttSettings;
            _scopeFactory = scopeFactory;
            _IoTCommunication = new IoTCommunication(mqttSettings);
            IoTClient.SensorMessageReceived += OnSensorMessageReceived;
            IoTClient.ClientConnectedEventHandler += OnClientConnected;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            await IoTClient.ConnectAsync();
            
        }

        async void OnClientConnected(object sender, EventArgs eventArgs)
        {
            await IoTClient.SubscribeAsync(_mqttSettings.SubscriptionTopic, QoSType.AtMostOnce);
        }

        void OnSensorMessageReceived(object sender, SensorMessageEventArgs eventArgs)
        {
            var sensorValue = eventArgs.SensorValue;
            var sensorName = sensorValue.Id;
            var value = sensorValue.Value;
            var valueUnit = sensorValue.ValueUnit;

            _logger.LogInformation("Message received: {time}, {sensorName}, {value}, {valueUnit}", DateTimeOffset.Now, sensorName, value, valueUnit ?? string.Empty);

            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<HomeAutomationContext>();
            var SensorModel = (from sensors in dbContext.Sensors
                               where sensors.Name == sensorName
                               select sensors).FirstOrDefault();

            if (SensorModel == null)
                return;

            var sensor = SensorControllerBase.CreateSensorController(SensorModel, dbContext);
            var sensorEvent = sensor.CreateEventController(value);

            sensorEvent.Save();
        }
    }
}
