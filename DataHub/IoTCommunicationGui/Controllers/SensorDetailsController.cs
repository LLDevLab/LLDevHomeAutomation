﻿using DbCommunicationLib;
using DbCommunicationLib.Model.Interfaces;
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
        readonly HomeAutomationContext _dbContext;
        public SensorDetailsController(ILogger<SensorsOverviewController> logger, HomeAutomationContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetDetail(int id)
        {
            var result = (from sensor in _dbContext.Sensors
                         where sensor.Id == id
                         select sensor).FirstOrDefault();

            return result != null ? Ok(result as ISensor) : NotFound();
        }
    }
}
