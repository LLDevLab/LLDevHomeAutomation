using System.Collections.Generic;

namespace IoTCommunicationGui.Dtos
{
    public class LineChartDto<T>
    {
        public string Name { get; init; }

        public IEnumerable<LineChartPointDto<T>> Series { get; init; }
    }
}
