using IoTCommunicationLib;
using IoTCommunicationLib.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.Json;
using System.Threading;

namespace IoTCommunicationLibTests
{
    [TestClass]
    public class MqttUnitTest
    {
        readonly IoTCommunication _publisher;
        readonly IClient _publisherClient;
        readonly IoTCommunication _subscriber;
        readonly IClient _subscriberClient;
        readonly MqttSettings _publisherSettings;
        readonly MqttSettings _subscriberSettings;

        bool _correctMessageReceived;

        Message _messageDto;
        string _message;

        public MqttUnitTest()
        {
            // NB! To run this test, please install mqtt brocker and change MqttSettings class accordingly
            _publisherSettings = new MqttSettings("PublisherClient");
            _publisher = new IoTCommunication(_publisherSettings);
            _publisherClient = _publisher.Client;

            _subscriberSettings = new MqttSettings("SubscriberClient");
            _subscriber = new IoTCommunication(_subscriberSettings);
            _subscriberClient = _subscriber.Client;
        }

        [TestMethod]
        public void SmartPostSensorTest()
        {
            _messageDto = new Message
            {
                Id = "PostBox",
                Value = "true",
                ValueUnit = null
            };
            _message = JsonSerializer.Serialize(_messageDto);
            TestSensor();
        }

        [TestMethod]
        public void Bmp280SensorTest()
        {
            _messageDto = new Message
            {
                Id = "Room1",
                Value = "20.1",
                ValueUnit = "C"
            };
            _message = JsonSerializer.Serialize(_messageDto);
            TestSensor();
        }

        void TestSensor()
        {
            _subscriberClient.SensorMessageReceived += OnSensorMessageReceived;
            _subscriberClient.ClientConnectedEventHandler += OnSubscriberConnected;

            var subscriberTask = _subscriberClient.ConnectAsync();

            _publisherClient.ClientConnectedEventHandler += OnPublisherConnected;

            Thread.Sleep(2000);
            _publisherClient.ConnectAsync();
            Thread.Sleep(5000);
            DisconnectAll();

            Assert.IsTrue(_correctMessageReceived);
        }

        void DisconnectAll()
        {
            _subscriberClient.DisconnectAsync();
            _publisherClient.DisconnectAsync();
        }

        void OnSubscriberConnected(object sender, EventArgs eventArgs)
        {
            _subscriberClient.SubscribeAsync(_subscriberSettings.SubscriptionTopic, QoSType.AtMostOnce).Wait();
        }

        void OnPublisherConnected(object sender, EventArgs eventArgs)
        {
            _publisherClient.PublishAsync(_publisherSettings.SubscriptionTopic, _message).Wait();
        }

        void OnSensorMessageReceived(object sender, SensorMessageEventArgs eventArgs)
        {
            var sensorValue = eventArgs.SensorValue;
            _correctMessageReceived = sensorValue.Id == _messageDto.Id && sensorValue.Value == _messageDto.Value && sensorValue.ValueUnit == _messageDto.ValueUnit;
        }
    }
}
