using System.Collections.Generic;

#nullable disable

namespace DbCommunicationLib.Model
{
    public partial class Chart
    {
        public Chart()
        {
            ChartSensorMaps = new HashSet<ChartSensorMap>();
        }

        public short Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ChartSensorMap> ChartSensorMaps { get; set; }
    }
}
