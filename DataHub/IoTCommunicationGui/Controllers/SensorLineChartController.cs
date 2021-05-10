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
            var sensorName = (from sensors in _context.Sensors
                          where sensors.Id == sensorId
                          select sensors.Name).First();

            var events = from sensorEvents in _context.SensorEvents
                            where sensorEvents.SensorId == sensorId &&
                            sensorEvents.EventDateTime >= dateFrom
                            // Ascending sort is needed because clustered index of a table is sorted in descendig order
                            orderby sensorEvents.EventDateTime ascending
                            select new 
                            { 
                                sensorEvents.EventDateTime, 
                                sensorEvents.EventDoubleValue 
                            };

            var result = new LineChartDto<double>
            {
                Name = sensorName,
                Series = events.Select(x => new LineChartPointDto<double>
                {
                    Name = x.EventDateTime.ToString("dd/MM/yyyy HH:mm"),
                    Value = Math.Round(x.EventDoubleValue.Value, 2)
                }) 
            };

            return new List<LineChartDto<double>> { result };
        }
    }
}
