using System;

namespace DbCommunicationLib.Model.Interfaces
{
    public interface ISensorEvent
    {
        long Id { get; }
        int SensorId { get; }
        DateTime EventDateTime { get; }
        double? EventDoubleValue { get; }
        bool? EventBooleanValue { get; }
    }
}
