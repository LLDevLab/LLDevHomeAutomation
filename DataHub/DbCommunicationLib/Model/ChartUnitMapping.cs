#nullable disable

namespace DbCommunicationLib.Model
{
    public partial class ChartUnitMapping
    {
        public short ChartId { get; set; }
        public short UnitId { get; set; }

        public virtual Chart Chart { get; set; }
        public virtual MeasurementUnit Unit { get; set; }
    }
}
