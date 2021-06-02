using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using DbCommunicationLib;
using IoTCommunicationGui.Dtos.Sensors;

namespace IoTCommunicationGui.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SensorController: ControllerBase
    {
        readonly HomeAutomationContext _context;
        public SensorController(HomeAutomationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<SensorDto> Get() => 
            from sensor in _context.SensorsDataViews
            orderby sensor.Id
            select new SensorDto 
            {
                Id = sensor.Id,
                Description = sensor.Description,
                InverseLogic = sensor.InverseLogic,
                IsActive = sensor.IsActive,
                Name = sensor.Name,
                SensorGroupName = sensor.SensorGroupName,
                UnitId = sensor.UnitId
            };

        [HttpGet("{id:int}")]
        public SensorDto GetDetail(int id) =>
            (from sensor in _context.SensorsDataViews
            where sensor.Id == id
            select new SensorDto
            {
                Id = sensor.Id,
                Description = sensor.Description,
                InverseLogic = sensor.InverseLogic,
                IsActive = sensor.IsActive,
                Name = sensor.Name,
                SensorGroupName = sensor.SensorGroupName,
                UnitId = sensor.UnitId
            }).First();

        [HttpGet("{sensorId:int}/events/{pageSize:int}&{pageIndex:int}")]
        public IEnumerable<SensorEventDto> GetEvents(int sensorId, int pageSize, int pageIndex)
        {
            var recToSkip = pageIndex * pageSize;
            var list = (from sensorEvent in _context.SensorEvents
                        where sensorEvent.SensorId == sensorId
                        orderby sensorEvent.EventDateTime descending
                        select new SensorEventDto 
                        {
                            Id = sensorEvent.Id,
                            EventBooleanValue = sensorEvent.EventBooleanValue,
                            EventDateTime = sensorEvent.EventDateTime,
                            EventDoubleValue = sensorEvent.EventDoubleValue,
                            SensorId = sensorEvent.SensorId
                        }).Skip(recToSkip).Take(pageSize);

            return list;
        }

        [HttpGet("{sensorId:int}/events")]
        public int GetEvents(int sensorId)
        {
            var cnt = (from sensorEvent in _context.SensorEvents
                       where sensorEvent.SensorId == sensorId
                       select sensorEvent).Count();

            return cnt;
        }
    }
}
