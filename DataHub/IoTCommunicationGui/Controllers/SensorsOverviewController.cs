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
    public class SensorsOverviewController: ControllerBase
    {
        readonly ILogger<SensorsOverviewController> _logger;
        readonly HomeAutomationContext _context;
        public SensorsOverviewController(ILogger<SensorsOverviewController> logger, IDbContextSettings options)
        {
            _logger = logger;
            _context = new HomeAutomationContext(options);
        }

        [HttpGet]
        public IEnumerable<SensorsDto> Get()
        {
            var queryResult = from sensor in _context.Sensors
                         orderby sensor.Id
                         select sensor;

            return queryResult.Select(x => x.GetController().GetDtoObject());
        }
    }
}
