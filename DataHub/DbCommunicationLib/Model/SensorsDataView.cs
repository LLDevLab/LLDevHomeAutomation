#nullable disable

namespace DbCommunicationLib.Model
{
    public partial class SensorsDataView
    {
        public int? Id { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public string Name { get; set; }
        public bool? InverseLogic { get; set; }
        public string SensorGroupName { get; set; }
        public short? UnitId { get; set; }
    }
}
