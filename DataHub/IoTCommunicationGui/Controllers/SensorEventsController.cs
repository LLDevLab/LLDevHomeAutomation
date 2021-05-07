using DbCommunicationLib;
using DbCommunicationLib.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace IoTCommunicationGui.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SensorEventsController : ControllerBase
    {
        readonly ILogger<SensorsOverviewController> _logger;
        readonly HomeAutomationContext _context;
        public SensorEventsController(ILogger<SensorsOverviewController> logger, HomeAutomationContext context)
        {
            _logger = logger;
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
