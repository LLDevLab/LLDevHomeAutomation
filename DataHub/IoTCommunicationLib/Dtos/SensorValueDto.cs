namespace IoTCommunicationLib.Dtos
{
    class SensorValueDto: ISensorValue
    {
        public string Id { get; set; }
        public string Value { get; set; }
        public string ValueUnit { get; set; }
    }
}
