namespace DbCommunicationLib.Model.Interfaces
{
    public interface ISensor
    {
        public int? Id { get; }
        public string Description { get; }
        public bool? IsActive { get; }
        public string Name { get; }
        public bool? InverseLogic { get; }
        public string SensorGroupName { get; }
        public short? UnitId { get; }
    }
}
