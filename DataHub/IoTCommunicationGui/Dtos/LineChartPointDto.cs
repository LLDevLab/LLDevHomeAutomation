namespace IoTCommunicationGui.Dtos
{
    public class LineChartPointDto<T>
    {
        public string Name { get; init; }
        public T Value { get; init; }
    }
}
