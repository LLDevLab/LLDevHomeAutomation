using System.Collections.Generic;

#nullable disable

namespace DbCommunicationLib.Model
{
    public partial class Chart
    {
        public Chart()
        {
            ChartUnitMappings = new HashSet<ChartUnitMapping>();
        }

        public short Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ChartUnitMapping> ChartUnitMappings { get; set; }
    }
}
