namespace IoTCommunicationGui.Dtos.Sensors
{
    public class SensorDto
    {
        public int? Id { get; init; }
        public string Description { get; init; }
        public bool? IsActive { get; init; }
        public string Name { get; init; }
        public bool? InverseLogic { get; init; }
        public string SensorGroupName { get; init; }
        public short? UnitId { get; init; }
    }
}
