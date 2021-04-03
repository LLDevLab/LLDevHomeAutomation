using DbCommunicationLib.Controller.SensorEvents;
using DbCommunicationLib.Dto;
using DbCommunicationLib.Model;

namespace DbCommunicationLib.Controller.Sensors
{
    abstract class SensorControllerBase: ISensorController
    {
        public Sensor SensorModel { get; private init; }
        protected SensorControllerBase(Sensor sensorModel)
        {
            SensorModel = sensorModel;
        }

        public int Id => SensorModel.Id;

        public string Name => SensorModel.Name;

        public string Description => SensorModel.Description;

        public bool? IsActive => SensorModel.IsActive;

        public SensorType Type => (SensorType)SensorModel.Type;

        public abstract ISensorEventController CreateNewEvent(string eventDescription);

        ISensorEventController ISensorController.CreateNewEvent(string eventDescription) => CreateNewEvent(eventDescription);

        public SensorsDto GetDtoObject() => new()
        {
            Id = SensorModel.Id,
            Name = SensorModel.Name,
            Description = SensorModel.Description,
            SensorType = (SensorType)SensorModel.Type,
            IsActive = SensorModel.IsActive,
            InverseOnOffLogic = SensorModel.InverseOnOffLogic
        };
    }
}
