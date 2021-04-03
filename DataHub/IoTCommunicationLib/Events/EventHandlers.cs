namespace IoTCommunicationLib
{
    delegate void ApplicationMessageEventHandler(object sender, ApplicationMessageEventArgs eventArgs);
    public delegate void SensorMessageEventHandler(object sender, SensorMessageEventArgs eventArgs);
}
