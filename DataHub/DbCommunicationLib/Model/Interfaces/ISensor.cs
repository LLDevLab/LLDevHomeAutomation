namespace DbCommunicationLib.Model.Interfaces
{
    public interface ISensor
    {
        int Id { get; }
        string Description { get; }
        bool? IsActive { get; }
        string Name { get; }
        bool? InverseLogic { get; }
        short SensorType { get; }
        short? UnitId { get; }
    }
}
