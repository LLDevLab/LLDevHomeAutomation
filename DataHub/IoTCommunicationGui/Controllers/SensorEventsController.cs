using DbCommunicationLib;
using DbCommunicationLib.Dto;
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
        public SensorEventsController(ILogger<SensorsOverviewController> logger, IDbContextSettings options)
        {
            _logger = logger;
            _context = new HomeAutomationContext(options);
        }

        [HttpGet("{sensorId:int}")]
        public IEnumerable<SensorEventsDto> Get(int sensorId)
        {
            var list = (from sensorEvent in _context.SensorEvents
                        where sensorEvent.SensorId == sensorId
                        orderby sensorEvent.EventDateTime descending
                        select sensorEvent).Take(5);

            var result = list.Select(x => x.GetController().GetDtoObject());

            return result;
        }
    }
}
