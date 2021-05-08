using DbCommunicationLib;
using DbCommunicationLib.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace IoTCommunicationGui.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SensorsOverviewController: ControllerBase
    {
        readonly HomeAutomationContext _context;
        public SensorsOverviewController(HomeAutomationContext context)
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
    }
}
