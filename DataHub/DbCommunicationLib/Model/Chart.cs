using System.Collections.Generic;

#nullable disable

namespace DbCommunicationLib.Model
{
    public partial class Chart
    {
        public Chart()
        {
            ChartSensorGroupsMappings = new HashSet<ChartSensorGroupsMapping>();
        }

        public short Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ChartSensorGroupsMapping> ChartSensorGroupsMappings { get; set; }
    }
}
