using System.Collections.Generic;

#nullable disable

namespace DbCommunicationLib.Model
{
    public partial class Sensor
    {
        public Sensor()
        {
            SensorEvents = new HashSet<SensorEvent>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public string Name { get; set; }
        public bool? InverseLogic { get; set; }
        public short SensorType { get; set; }

        public virtual SensorType SensorTypeNavigation { get; set; }
        public virtual ICollection<SensorEvent> SensorEvents { get; set; }
    }
}
