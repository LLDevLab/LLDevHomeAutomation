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

        [HttpGet("{sensorId:int}")]
        public IEnumerable<ISensorEvent> Get(int sensorId)
        {
            var list = (from sensorEvent in _context.SensorEvents
                        where sensorEvent.SensorId == sensorId
                        orderby sensorEvent.EventDateTime descending
                        select sensorEvent).Take(5);

            return list;
        }
    }
}
