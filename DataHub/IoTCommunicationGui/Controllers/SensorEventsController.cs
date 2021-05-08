using DbCommunicationLib;
using DbCommunicationLib.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace IoTCommunicationGui.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SensorEventsController : ControllerBase
    {
        readonly HomeAutomationContext _context;
        public SensorEventsController(HomeAutomationContext context)
        {
            _context = context;
        }

        [HttpGet("{sensorId:int}&{pageSize:int}&{pageIndex:int}")]
        public IEnumerable<ISensorEvent> Get(int sensorId, int pageSize, int pageIndex)
        {
            var recToSkip = pageIndex * pageSize;
            var list = (from sensorEvent in _context.SensorEvents
                        where sensorEvent.SensorId == sensorId
                        orderby sensorEvent.EventDateTime descending
                        select sensorEvent).Skip(recToSkip).Take(pageSize);

            return list;
        }

        [HttpGet("{sensorId:int}")]
        public int Get(int sensorId)
        {
            var cnt = (from sensorEvent in _context.SensorEvents
                        where sensorEvent.SensorId == sensorId
                        select sensorEvent).Count();

            return cnt;
        }
    }
}
