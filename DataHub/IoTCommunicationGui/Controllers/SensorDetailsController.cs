using DbCommunicationLib;
using DbCommunicationLib.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace IoTCommunicationGui.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SensorDetailsController: ControllerBase
    {
        readonly ILogger<SensorsOverviewController> _logger;
        readonly HomeAutomationContext _context;
        public SensorDetailsController(ILogger<SensorsOverviewController> logger, IDbContextSettings options)
        {
            _logger = logger;
            _context = new HomeAutomationContext(options);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetDetail(int id)
        {
            var result = (from sensor in _context.Sensors
                         where sensor.Id == id
                         select sensor).FirstOrDefault();

            return result != null ? Ok(result.GetController().GetDtoObject()) : NotFound();
        }
    }
}
