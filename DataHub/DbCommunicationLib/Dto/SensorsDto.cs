namespace DbCommunicationLib.Dto
{
    public class SensorsDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public bool? IsActive { get; init; }
        public bool? InverseOnOffLogic { get; init; }
    }
}
