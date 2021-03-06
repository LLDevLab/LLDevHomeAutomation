﻿using System;

#nullable disable

namespace DbCommunicationLib.Model
{
    public partial class SensorEvent
    {
        public long Id { get; set; }
        public int SensorId { get; set; }
        public DateTime EventDateTime { get; set; }
        public double? EventDoubleValue { get; set; }
        public bool? EventBooleanValue { get; set; }

        public virtual Sensor Sensor { get; set; }
    }
}
