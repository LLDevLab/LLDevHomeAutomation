using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using DbCommunicationLib;
using IoTCommunicationGui.Dtos.Sensors;
using System;
using IoTCommunicationGui.Exceptions;

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

        [HttpPost]
        public IActionResult PostSensorDetails(SensorDto sensorDto)
        {
            try
            {
                if (sensorDto.Id.HasValue)
                    UpdateSensor(sensorDto);
                else
                    InsertSensor(sensorDto);
            }
            catch(GuiRecordNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(sensorDto);
        }

        [HttpDelete("{sensorId:int}")]
        public IActionResult DeleteSensor(int sensorId)
        {
            var sensor = (from sensors in _context.Sensors
                          where sensors.Id == sensorId
                          select sensors).FirstOrDefault();

            if(sensor == null)
                return NotFound(sensorId);

            _context.Remove(sensor);
            _context.SaveChanges();

            return Ok(sensorId);
        }

        void UpdateSensor(SensorDto sensorDto)
        {
            var sensorId = sensorDto.Id.Value;
            var sensor = (from sensors in _context.Sensors
                          where sensors.Id == sensorId
                          select sensors).FirstOrDefault();

            if (sensor == null)
                throw new GuiRecordNotFoundException($"Sensor with id {sensorId} not found.");

            sensor.Description = sensorDto.Description;
            sensor.InverseLogic = sensorDto.InverseLogic;
            sensor.IsActive = sensorDto.IsActive.Value;

            _context.SaveChanges();
        }

        void InsertSensor(SensorDto sensorDto)
        {
            var sensorGroupName = sensorDto.SensorGroupName;
            var sensorGroup = (from sensorGroups in _context.SensorGroups
                               where sensorGroups.Name == sensorGroupName
                               select sensorGroups).FirstOrDefault();

            if (sensorGroup == null)
                throw new GuiRecordNotFoundException($"Sensor group '{sensorGroupName}' not found.");

            var sensor = new DbCommunicationLib.Model.Sensor()
            {
                Name = sensorDto.Name,
                Description = sensorDto.Description,
                InverseLogic = sensorDto.InverseLogic,
                IsActive = sensorDto.IsActive.Value,
                SensorGroupId = sensorGroup.Id
            };
            _context.Sensors.Add(sensor);
            _context.SaveChanges();
        }
    }
}
