using DbCommunicationLib.Controller.SensorEvents;
using DbCommunicationLib.Dto;
using DbCommunicationLib.Model;

namespace DbCommunicationLib.Controller.Sensors
{
    public interface ISensorController
    {
        Sensor SensorModel { get; }
        int Id { get; }

        string Name { get; }

        string Description { get; }

        bool? IsActive { get; }

        SensorTypeEnum SensorType { get; }

        ISensorEventController CreateNewEvent(string sensorValue);
        SensorsDto GetDtoObject();
    }
}
