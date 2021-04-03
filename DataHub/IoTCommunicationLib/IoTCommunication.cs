using IoTCommunicationLib.Abstractions;
using IoTCommunicationLib.Abstractions.Communication;
using IoTCommunicationLib.Communications.Mqtt;
using IoTCommunicationLib.IoTSettings;
using System;

namespace IoTCommunicationLib
{
    public class IoTCommunication: IDisposable
    { 
        public IClient Client { get; private set; }
        public IoTCommunication(ICommunicationSettings settings)
        {
            switch (settings.Type)
            {
                case CommunicationType.Mqtt:
                    Client = new MqttClientAdapter(new MqttClient(settings));
                    break;
            }
        }

        #region IDisposable
        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (Client is IDisposable disposable)
                    {
                        disposable.Dispose();
                    }
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
