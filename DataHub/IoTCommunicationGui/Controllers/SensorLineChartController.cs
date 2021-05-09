using DbCommunicationLib;
using IoTCommunicationGui.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IoTCommunicationGui.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SensorLineChartController
    {
        readonly HomeAutomationContext _context;

        public SensorLineChartController(HomeAutomationContext context)
        {
            _context = context;
        }

        [HttpGet("{sensorId:int}")]
        public IEnumerable<LineChartDto<double>> Get(int sensorId)
        {
#if DEBUG
            var dateFrom = new DateTime(2021, 04, 20);
#else
            var dateFrom = DateTime.Now.AddDays(-2);
#endif
            var sensor = (from sensors in _context.Sensors
                          where sensors.Id == sensorId
                          select sensors).First();

            var sensorEvents = sensor.SensorEvents.Where(x => x.EventDateTime >= dateFrom);

            var result = new LineChartDto<double>
            {
                Name = sensor.Name,
                Series = sensorEvents.Select(x => new LineChartPointDto<double>
                {
                    Name = x.EventDateTime.ToString("dd/MM/yyyy HH:mm"),
                    Value = Math.Round(x.EventDoubleValue.Value, 2)
                })
            };

            return new List<LineChartDto<double>> { result };
        }
    }
}
