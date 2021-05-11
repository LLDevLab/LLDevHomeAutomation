using DbCommunicationLib;
using DbCommunicationLib.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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
        public IEnumerable<ISensor> Get()
        {
            var queryResult = from sensor in _context.Sensors
                              orderby sensor.Id
                              select sensor;

            return queryResult;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetDetail(int id)
        {
            var result = (from sensor in _context.Sensors
                         where sensor.Id == id
                         select sensor).FirstOrDefault();

            return result != null ? Ok(result as ISensor) : NotFound();
        }

        [HttpGet("{sensorId:int}/Events/{pageSize:int}&{pageIndex:int}")]
        public IEnumerable<ISensorEvent> GetEvents(int sensorId, int pageSize, int pageIndex)
        {
            var recToSkip = pageIndex * pageSize;
            var list = (from sensorEvent in _context.SensorEvents
                        where sensorEvent.SensorId == sensorId
                        orderby sensorEvent.EventDateTime descending
                        select sensorEvent).Skip(recToSkip).Take(pageSize);

            return list;
        }

        [HttpGet("{sensorId:int}/Events")]
        public int GetEvents(int sensorId)
        {
            var cnt = (from sensorEvent in _context.SensorEvents
                       where sensorEvent.SensorId == sensorId
                       select sensorEvent).Count();

            return cnt;
        }
    }
}
