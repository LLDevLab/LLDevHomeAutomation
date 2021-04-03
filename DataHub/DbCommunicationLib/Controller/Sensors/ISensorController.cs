using DbCommunicationLib.Controller.SensorEvents;
using DbCommunicationLib.Dto;
using DbCommunicationLib.Model;
using System.Collections.Generic;

namespace DbCommunicationLib.Controller.Sensors
{
    public interface ISensorController
    {
        Sensor SensorModel { get; }
        int Id { get; }

        string Name { get; }

        string Description { get; }

        bool? IsActive { get; }

        SensorType Type { get; }

        ISensorEventController CreateNewEvent(string eventDescription);
        SensorsDto GetDtoObject();
    }
}
